                List<string> excList = new List<string>();
                //added column from table, which can varies
                excList.Add((string)column.ColumnName);
    
                string[] excelList = new string[13];
    
                for (int i = 0; i < excList.Count; i++)
                {
                    excelList[i] = excList[i];
                }
    
                for (int i = (excList.Count - 1); i < 13; i++)
                {
                    excelList[i] = string.Empty;
                }
