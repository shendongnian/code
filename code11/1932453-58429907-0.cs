           // Getting the latest .Count file:
            string directory = "C:\\MainFolder";
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataRow row;
            DataColumn column;
            column = new DataColumn();
          
            dt.Columns.Add("Count_File_Date", typeof(String));
            dt.Columns.Add("Count_File_Name", typeof(String));
            dt.Columns.Add("Count_File_LMD", typeof(String));
            dt.Columns.Add("Switch_File_Name", typeof(String));
            dt.Columns.Add("Switch_File_Date", typeof(String));
            dt.Columns.Add("Data_File_Name", typeof(String));
            dt.Columns.Add("Data_File_LMD", typeof(String));
            row = dt.NewRow();
            dt.Rows.Add(row);
            var directories = Directory.GetDirectories(directory);
            foreach (string subdirectory in directories)
            {
                if (Directory.GetFiles(subdirectory, "*.count").Length == 0)
                {
                    row["Count_File_Name"] = "Count File Not Found";
                    
                }
                else
                {
                    // Getting the values of count file
                    DateTime Count_L_M_D;
                    string Count_File_Name;
                    string[] Count_filePath1 = Directory.GetFiles(subdirectory, "*.count");
                    string Content = File.ReadAllText(@Count_filePath1[0]);
                    string loadedDate = DateTime.ParseExact(Content.Substring(9, 8), "yyyyMMdd",
                                    CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
                    DateTime Datevalue = DateTime.Parse(loadedDate);
                    Count_File_Name = Path.GetFileName(Count_filePath1[0]);
                    Count_L_M_D = Directory.GetLastWriteTime(Count_filePath1[0]);
                    row["Count_File_Date"] = Datevalue;
                    row["Count_File_Name"] = Count_File_Name;
                    row["Count_File_LMD"] = Count_L_M_D;
                }
                if (Directory.GetFiles(subdirectory, "*.switch").Length == 0)
                {
                    row["Switch_File_Name"] = "Switch File Not Found";
                }
                else
                {
                    string[] Switch_filePath = Directory.GetFiles(subdirectory, "*.switch");
                    DateTime Switch_L_M_D;
                    string S_File_Name;
                    S_File_Name = Path.GetFileName(Switch_filePath[0]);
                    Switch_L_M_D = Directory.GetLastWriteTime(Switch_filePath[0]);
                        row["Switch_File_Name"] = S_File_Name;
                        row["Switch_File_Date"] = Switch_L_M_D;
                     }
                if (Directory.GetFiles(subdirectory, "*.data").Length == 0)
                {
                    row["Data_File_Name"] = "Data File Not Found";
                }
                else
                {
                    string[] Data_filePath = Directory.GetFiles(directory, "*.data", SearchOption.AllDirectories);
                    List<DateTime> DataFileLMDate_List = new List<DateTime>();
                    List<string> Data_FileName_List = new List<string>();
                    DateTime Data_L_M_D;
                    string Data_File_Name;
                        Data_File_Name = Path.GetFileName(Data_filePath[0]);
                        Data_FileName_List.Add(Data_File_Name);
                        Data_L_M_D = Directory.GetLastWriteTime(Data_filePath[0]);
                        DataFileLMDate_List.Add(Data_L_M_D);
                        row["Data_File_Name"] = Data_File_Name;
                        row["Data_File_LMD"] = Data_L_M_D;
                    
                }
            }
