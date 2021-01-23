    public class ContactImportService : ServiceBase
    {
        
        private DataTable csvData;
     
        //...   
    
        public void DifferentialImport(Guid ID)
        {
            //This is a list of ContactIDs which we come across in the CSV during processing.
            //Any records in the DB which have an ID not in this list will be deleted.
            List<string> currentIDs = new List<string>();
            lock (syncRoot)
            {
                jobQueue[ID].TotalItems = (short)csvData.Rows.Count;
                jobQueue[ID].Status = "Loading contact records";
            }
            //Load existing data into memory from Database.
            SqlConnection connection = 
                new SqlConnection(Utilities.ConnectionStrings["MyDataBase"].ConnectionString);
            SqlCommand command = new SqlCommand("SELECT " +
                    "[ContactID],[FirstName],[LastName],[Title]" +
                    // Etc...
                    "FROM [Contact]" +
                    "ORDER BY [ContactID]", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable dbData = new DataTable();
            dbData.Load(reader);
            reader = null;
            lock (syncRoot)
            {
                jobQueue[ID].Status = "Merging records";
            }
            int affected = -1;
            foreach (DataRow row in csvData.Rows)
            {
                string contactID = row["ContactID"].ToString();
                //Have we already processed a record with this ID? If so, skip.
                if (currentIDs.IndexOf(contactID) != -1)
                    break;
                currentIDs.Add(row["ContactID"].ToString());
                string csvValues = Utilities.GetDataRowString(row);
                //Get a row from our DB DataTable with the same ID that we got previously:
                DataRow dbRecord = (from record in dbData.AsEnumerable()
                                where record.Field<string>("ContactID") == contactID
                                select record).SingleOrDefault();
                //Found an ID not in the database yet... add it.
                if (dbRecord == null)
                {
                    command = new SqlCommand("INSERT INTO [Contact] " +
                        "... VALUES ...", connection);
                    connection.Open();
                    affected = command.ExecuteNonQuery();
                    connection.Close();
                    if (affected < 1)
                    {
                        lock (syncRoot)
                        {
                            jobQueue[ID].FailedChanges++;
                        }
                    }
                }
                //Compare the DB record with the CSV record:
                string dbValues = Utilities.GetDataRowString(dbRecord);
                //Values are different, we need to update the DB to match.
                if (csvValues == dbValues)
                    continue;
                //TODO: Dynamically build the update query based on the specific columns which don't match using StringBulder.
                command = new SqlCommand("UPDATE [Contact] SET ... WHERE [Contact].[ContactID] = @ContactID");
                //...
                command.Parameters.Add("@ContactID", SqlDbType.VarChar, 100, contactID);
                connection.Open();
                affected = command.ExecuteNonQuery();
                connection.Close();
                //Update job counters.
                lock (syncRoot)
                {
                    if (affected < 1)
                        jobQueue[ID].FailedChanges++;
                    else
                        jobQueue[ID].UpdatedItems++;
                    jobQueue[ID].ProcessedItems++;
                    jobQueue[ID].Status = "Deleting old records";
                }
            } // CSV Rows
            //Now that we know all of the Contacts which exist in the CSV currently, use the list of IDs to build a DELETE query
            //which removes old entries from the database.
            StringBuilder deleteQuery = new StringBuilder("DELETE FROM [Contact] WHERE ");
            //Find all the ContactIDs which are listed in our DB DataTable, but not found in our list of current IDs.
            List<string> dbIDs = (from record in dbData.AsEnumerable()
                                  where currentIDs.IndexOf(record.Field<string>("ContactID")) == -1
                                  select record.Field<string>("ContactID")).ToList();
            if (dbIDs.Count != 0)
            {
                command = new SqlCommand();
                command.Connection = connection;
                for (int i = 0; i < dbIDs.Count; i++)
                {
                    deleteQuery.Append(i != 0 ? " OR " : "");
                    deleteQuery.Append("[Contact].[ContactID] = @" + i.ToString());
                    command.Parameters.Add("@" + i.ToString(), SqlDbType.VarChar, 100, dbIDs[i]);
                }
                command.CommandText = deleteQuery.ToString();
                connection.Open();
                affected = command.ExecuteNonQuery();
                connection.Close();
            }
            lock (syncRoot)
            {
                jobQueue[ID].Status = "Finished";
            }
            remove(ID);
        }
    }
