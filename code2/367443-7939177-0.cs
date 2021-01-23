        DataTable dt = new DataTable("MyTable");
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    if (row[column] != null) // this will checks the null values also if you want to check
                    {
                           // do what ever you  want 
                    }
                 }
            }
