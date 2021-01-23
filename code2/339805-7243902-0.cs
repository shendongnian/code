                    txtLog.Text += "Ready To Start!\r\n";
                    Data = "USER XXXX" + CRLF;
                    szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
                    NetStrm.Write(szData, 0, szData.Length);
                    txtLog.Text += RdStrm.ReadLine() + CRLF;
                    Data = "PASS XXXX" + CRLF;
                    szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
                    NetStrm.Write(szData, 0, szData.Length);
                    txtLog.Text += RdStrm.ReadLine() + CRLF;
                    
                    Data = "STAT" + CRLF;
                    szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
                    NetStrm.Write(szData, 0, szData.Length);
                    txtLog.Text += RdStrm.ReadLine() + CRLF + CRLF + CRLF + CRLF + CRLF;
                    Data = "RETR 1" + CRLF;
                    szData = System.Text.Encoding.ASCII.GetBytes(Data.ToCharArray());
                    NetStrm.Write(szData, 0, szData.Length);
                    txtLog.Text += RdStrm.ReadLine() + CRLF;
                  
                    string szTemp;
                    szTemp = RdStrm.ReadLine();
                    while(szTemp != ".") // POP3 uses . as the end of a message
                        {
                            
                            txtLog.Text += szTemp + CRLF;
                            szTemp = RdStrm.ReadLine();
                            
                                                   
                        }
                    
                    
                }
