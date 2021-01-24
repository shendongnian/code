    @jdweng: thanks very much for your input. I have used the below line of code to get it done                                                                                                            string sTest= string.Empty;                                                                                                            List<SortLines> lines = new List<SortLines>();                
                List<String> FinalLines = new List<String>();
                using (StreamReader sr = new StreamReader(@"C:\data\Input1.txt))
                {                  
                        sr.ReadLine();
                    
                    string line = "";
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        //line = line.Trim();
                        if (line.Length > 0)
                        {
                            line = line.Replace(" ", "*");
                            SortLines newLine = new SortLines()
                            {
                                key = line.Substring(1, 7),
                                line = line
                            };                          
                            if (sTest != newLine.key)
                            {
                                //Add the Line Items to String List
                                sOuterLine = sTest + sOneLine;
                                FinalLines.Add(sOuterLine);
                                string sFinalLine = newLine.line.Remove(1, 7);
                                string snewLine = newLine.key + sFinalLine;
                                sTest = snewLine.Substring(0, 7);
                                //To hold the data for the 1st occurence
                                sOtherLine = snewLine.Remove(0, 7);
                                bOtherLine = true;
                                string sKey = newLine.key;
                                lines.Add(newLine);
                            }
                            else if (sTest == newLine.key)
                            {
                                
                                string sConcatLine = String.Empty;
                                string sFinalLine = newLine.line.Remove(1, 7);
                                //Check if 1st Set
                                if (bOtherLine == true)
                                {
                                    sOneLine = sOtherLine + sFinalLine;
                                    bOtherLine = false;
                                }
                            //If not add subsequent data
                                else
                                {
                                    sOneLine = sOneLine + sFinalLine;
                                }
                                //Check for the last line in the flat file
                                if (sr.Peek() == -1)
                                {
                                    sOuterLine = sTest + sOneLine;
                                    FinalLines.Add(sOuterLine);
                                }                                                             
                            }
                            
                        }
                    }
                }
                //Remove the Empty List
                FinalLines.RemoveAll(x => x == "");              
                StreamWriter srWriter = new StreamWriter(@"C:\data\test.txt);
                foreach (var group in FinalLines)
                {
                    srWriter.WriteLine(group);                    
                }
                srWriter.Flush();
                srWriter.Close();              
