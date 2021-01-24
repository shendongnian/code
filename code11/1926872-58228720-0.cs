var saved_ids = new List<String>();
foreach (String args1line in File.ReadLines(args[1]))
                {
                    
                    foreach (String args2line in File.ReadLines(args[2]))
                    {
                        
                        if (args1line.Contains(args2line))
                        {
                            saved_ids.Add(args2line);
                            
                                                                                                       
                        }
                        
                        
                    }
                }
                using (System.IO.StreamReader sr1 = new System.IO.StreamReader(args[1]))
                        {
                            using (System.IO.StreamReader sr2 = new System.IO.StreamReader(args[2]))
                            {
                                
                                
                                string line1, line2;
                                
                                
                                while ((line1 = sr1.ReadLine()) != null)
                                  {
                                    
                                    while ((line2 = sr2.ReadLine()) != null)
                                     {
                                        
                                        
                                        if (line1.Contains(line2))
                                        {
                                            
                                            saved_ids.Add(line2);
                                            break;
                                           
                                        }
                                        if (!line1.StartsWith(">"))
                                        {
                                            break; 
                                        }
                                        if (saved_ids.Contains(line1))
                                        {
                                            
                                            break;
                                        }
                                        if (saved_ids.Contains(line2))
                                        {
                                            break;
                                        }
                                        if (!line1.Contains(line2))
                                        {
                                            saved_ids.Add(line2);
                                            WriteLine("The sequence ID {0} does not exist", line2);
                                        }
                                    }
                                    if (line2 == null)
                                    {
                                        sr2.DiscardBufferedData();
                                        sr2.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);
                                        continue;
                                    }
                                }
                            }
                        }
