        public static DataSet ConvertTabFiles(string File, string TableName, string delimiter)
        {
            //The DataSet to Return
            DataSet result = new DataSet();
            //Open the file in a stream reader.
            StreamReader s;
            try
            {
                s = new StreamReader(@File);
            }
            catch
            {
                MessageBox.Show("Can't perform operation on file: " + File);
                return result;
            }
            //Split the first line into the columns  
            string[] columns = null;
            try
            {
                columns = s.ReadLine().Split(delimiter.ToCharArray());
            }
            catch
            {
                MessageBox.Show("Can't parse the file " + File + ", please try again!");
                return result;
            }
            //Add the new DataTable to the RecordSet
            result.Tables.Add(TableName);
            //MessageBox.Show("Add the new DataTable to the RecordSet");
            //Cycle the colums, adding those that don't exist yet 
            //and sequencing the one that do.
            foreach (string col in columns)
            {
                bool added = false;
                string next = "";
                int i = 0;
                while (!added)
                {
                    //Build the column name and remove any unwanted characters.
                    string columnname = col + next;
                    //See if the column already exists
                    if (!result.Tables[TableName].Columns.Contains(columnname))
                    {
                        //if it doesn't then we add it here and mark it as added
                        result.Tables[TableName].Columns.Add(columnname);
                        added = true;
                    }
                    else
                    {
                        //if it did exist then we increment the sequencer and try again.
                        i++;
                        next = "_" + i.ToString();
                    }
                }
            }
            //Read the rest of the data in the file.        
            string AllData = s.ReadToEnd();
            string[] rows = AllData.Split("\r\n".ToCharArray());
            //Now add each row to the DataSet        
            foreach (string r in rows)
            {
                //Split the row at the delimiter.
                string[] items = r.Split(delimiter.ToCharArray());
                //Add the item
                result.Tables[TableName].Rows.Add(r);
            }
            //Return the imported data.
            return result;
        }
