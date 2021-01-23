                MySqlCommand Command = connection.CreateCommand();
                connection.Open();
                //SqlCommand Command = new SqlCommand();
                MySqlDataReader SQLRD;
                Command.CommandText = "Select * from Attendance";
                //connection.Open();
                SQLRD = Command.ExecuteReader();
                string data = "";
                while (SQLRD.Read())
                {
                    data += SQLRD[0].ToString()+"\n";
                    data += SQLRD[1].ToString()+"\n";
                }
                SQLRD.Close();
                connection.Close();
                string filename = @"F:\download.csv";
                FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(data);
                sw.Flush();
                sw.Close();
                fs.Close();
            }
