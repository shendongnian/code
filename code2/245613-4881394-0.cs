     //CHECK IF PART NUMBER EXIST ON ZTE
                        if (_dSet.Tables[0].Rows.Count > 0)
                        {
                          
                        }
                        else
                        {
                            i++;
                            builder.Append(serverA.OduModelNumber.ToString()).AppendLine();
                        }
                    }
                   
                    if(i > 0 )
                    {
                        MessageBox.Show(builder.ToString());
                    }
                    else
                    {
                        lblStatus.Text =  @"Data has been Loaded";
                    }
