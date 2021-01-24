    using System;
    using System.Data;
    namespace CompareLinuxWithWindow
    {
        class Program
        {
        static void Main(string[] args)
        {
            DataTable dt= ConvertToDataTable(@"C:\Users\manchunl\Desktop\Sample.txt", 10);
            DataTable dt2= ConvertToDataTable(@"C:\Users\manchunl\Desktop\Sample.txt2", 10);
            //Add these lines
            for(int i=0;i<dt.Rows.Count;i++) //looping through all rows including the column. change `i=1` if need to exclude the columns display
            {
                for (int j = 0; j < dt.Columns.Count; j++) //looping through all columns
                {
                    Console.WriteLine(dt.Rows[i][j]); //display of the data
                }
            }
            //End of change
            //Added for 2nd txt file
           for(int i=0;i<dt2.Rows.Count;i++) //looping through all rows including the column. change `i=1` if need to exclude the columns display
            {
                for (int j = 0; j < dt2.Columns.Count; j++) //looping through all columns
                {
                    Console.WriteLine(dt2.Rows[i][j]); //display of the data
                }
            }
           //End :: Added for 2nd txt file
            Console.WriteLine("Press enter to exit.");
            Console.Read();
        }
        public static DataTable ConvertToDataTable(string filePath, int numberOfColumns)
        {
            DataTable tbl = new DataTable();
            for (int col = 0; col < numberOfColumns; col++)
                tbl.Columns.Add(new DataColumn("Column" + (col + 1).ToString()));
            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                var cols = line.Split(',');
                DataRow dr = tbl.NewRow();
                for (int cIndex = 0; cIndex < numberOfColumns; cIndex++)//changed hardcoded value of 10 to numberOfColumns
                {
                    dr[cIndex] = cols[cIndex];
                }
                tbl.Rows.Add(dr);
            }
            return tbl;
        }
    }
    }
