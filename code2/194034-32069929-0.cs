     `public Boolean PreparCVS(string DateOne, string DataTwo)
        {
            try
            {
            // Create the `DataTable` structure according to your data source
                DataTable table = new DataTable();
                table.Columns.Add("HeaderOne", typeof(string));
                table.Columns.Add("HeaderTwo", typeof(String));
                // Iterate through data source object and fill the table
                table.Rows.Add(HeaderOne, HeaderTwo);
                //Creat CSV File
                CreateCSVFile(table, sCsvFilePath);
                return true;
            }
            catch (Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }`
