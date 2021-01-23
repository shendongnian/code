            string ExportFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Test.xlsx");
            string DSN = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", ExportFile);
            using (System.Data.OleDb.OleDbConnection Con = new System.Data.OleDb.OleDbConnection(DSN))
            {
                Con.Open();
                using (System.Data.OleDb.OleDbCommand Com = new System.Data.OleDb.OleDbCommand())
                {
                    Com.Connection = Con;
                    Com.CommandText = "CREATE TABLE [TestSheet] (A1 varChar(255), B1 varChar(255), C1 varChar(255))";
                    Com.ExecuteNonQuery();
                    string A1 = new string('A', 255);
                    string B1 = new string('B', 255);
                    string C1 = new string('C', 255);
                    Com.CommandText = string.Format("INSERT INTO [TestSheet] (A1, B1, C1) VALUES ('{0}', '{1}', '{2}')", A1, B1, C1);
                    for (var i = 1; i <= 200000; i++)
                    {
                        Com.ExecuteNonQuery();
                    }
                }
                Con.Close();
            }
