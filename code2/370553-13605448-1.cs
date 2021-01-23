    try
    {
        // Run the SQL statement, and then get the returned rows to the DataReader.
        SqlDataReader MyDataReader = MyCommand.ExecuteReader();
        //note AT THIS POINT there is an exception in MyDataReader
        //if I view MyDataReader in Watch I see this in base->ResultsView->base
        //Conversion failed when converting the varchar value 'lwang' to data type int
        //and errors count is 1 but there is no exception catch!!
        int iRow = 0;
        if (MyDataReader.HasRows)
        {
            int iCol = 0;
            while (MyDataReader.Read())
            {
                //dt.Load(MyDataReader);
                List<String> strFields = new List<String>();
    
                for (int iField = 0; iField < MyDataReader.FieldCount; iField++)
                {
                    strReturn = strReturn + MyDataReader[iField] + ",";
                    strFields.Add(MyDataReader[iField].ToString());
                }
                DataRows.Add(strFields);
                iRow++;
            }
        }
    }
    catch (Exception ex)
    {
        //no exception is caught in this case!!  This code is never reached!!
        strError = "An error occurred getting the data table: " + MyCommand.CommandText + " " + ex.ToString();
        throw new Exception(strError);
        return (DataRows);
    }
    finally
    {
        Connection.Close();
    }
        return (DataRows);
    }
