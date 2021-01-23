        private static DataTable GetEmployeeData()
        {
            string line;
            string[] columnValues;
            char[] columnSeperator = new char[] { ',' };
            DataTable dt = new DataTable();
            try
            {
                FileStream employeeFile = new FileStream(@"..\..\EmployeeDetails.txt", FileMode.Open);
                StreamReader sr = new StreamReader(employeeFile);
                // Obtain the columns from the first line.
                line = sr.ReadLine();
                columnValues = line.Split(columnSeperator);
                for (int x = 0; x <= columnValues.GetUpperBound(0); x++)
                {
                    // Add the column to the table
                    dt.Columns.Add(columnValues[x]);
                }
                
                line = sr.ReadLine();
                while (line != null)
                {
                    // Split row of data into string array
                    columnValues = line.Split(columnSeperator);
                    // add a new row with all of the values
                    dt.Rows.Add(columnValues);
                }
                sr.Close();
                return dt;
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
                return dt;
            }
        }
