    while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    line = line.Trim();
                    if (line.StartsWith("addTestingPageContentText"))
                    {
                        string temp;
                        string pattern = "\"([^\"]+)\"";
                        Regex r = new Regex(pattern);
                        MatchCollection regs = r.Matches(line);
    
    
                        object[] array1 = new object[2];                    
    
                        
    
                        foreach (Match reg in regs)
                        {
    
                            temp = reg.ToString();
                            temp = temp.Replace("\"", "");
    
                            if (array1[0] == null)
                                array1[0] = temp;
                            else
                                array1[1] = temp;
                        }
    
                        if (regs.Count > 0)
                            contentTable_grd.Rows.Add(array1);
                    }
                }
