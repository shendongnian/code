     DataTable dt = new DataTable();
     // For each row, print the values of each column.
        foreach(DataRow row in dt .Rows)
        {
            foreach(DataColumn column in dt .Columns)
            {
                Console.WriteLine(row[column]);
            }
        }
