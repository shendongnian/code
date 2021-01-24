     private void FormatRawData_2(string rawData)
            {
    
                string[] data = Regex.Split(rawData, "\r\n");
                if (rawData.Contains(@Config.DataPart))
                {
                    int index = Array.IndexOf(data, @Config.DataPart);
                    
                    for (int ctr = index + @Config.RowDataStart; ctr < data.Length; ctr++)
                    {
                        string[] lineData = Regex.Split(data[ctr], @"[\s+\t\n]");
    
                        int dataCtr = 1;
    
                        for (int lineCtr = 0; lineCtr < lineData.Length; lineCtr++)
                        {
                            if (lineData[lineCtr] != string.Empty)
                            {
    
                                if (dataCtr == Config.DataColumn)
                                {
                                    if (lineData[lineCtr].Contains(")"))
                                    {
                                        SetTextProcessed(lineData[lineCtr].Remove(lineData[lineCtr].Length - 4));
                                        break;
                                    }
                                }
                                dataCtr++;
                            }
    
                        }
    
                    }
    
                }
                else
                {
                    MessageBox.Show("Received data is not complete");
                }
            }
