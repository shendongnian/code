        public static double TestADONET_Insert_FromCsv()
        {
            StringBuilder names = new StringBuilder();
            for (int k = 0; k < 20; k++)
            {
                string fieldName = "Field" + (k + 1).ToString();
                if (k > 0)
                {
                    names.Append(",");
                }
                names.Append(fieldName);
            }
            DateTime start = DateTime.Now;
            StreamWriter sw = new StreamWriter("tmpdata.csv");
            sw.WriteLine(names);
            for (int i = 0; i < 100000; i++)
            {
                for (int k = 0; k < 19; k++)
                {
                    sw.Write(i + k);
                    sw.Write(",");
                }
                sw.WriteLine(i + 19);
            }
            sw.Close();
            using (OleDbConnection conn = new OleDbConnection(Properties.Settings.Default.AccessDB))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM TEMP";
                int numRowsDeleted = cmd.ExecuteNonQuery();
                Console.WriteLine("Deleted {0} rows from TEMP", numRowsDeleted);
                StringBuilder insertSQL = new StringBuilder("INSERT INTO TEMP (")
                    .Append(names)
                    .Append(") SELECT ")
                    .Append(names)
                    .Append(@" FROM [Text;Database=.;HDR=yes].[tmpdata.csv]");
                cmd.CommandText = insertSQL.ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            double elapsedTimeInSeconds = DateTime.Now.Subtract(start).TotalSeconds;
            Console.WriteLine("Append took {0} seconds", elapsedTimeInSeconds);
            return elapsedTimeInSeconds;
        }
