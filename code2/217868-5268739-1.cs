    public void DisplayList()
            {
                
                    bool check = true;	// true = use oldData
    
                    if ((oldData[0] != newData[0]) || ((oldData[0] == newData[0]) && (oldData[6] != newData[6])))
                    {
                        check = false;	// false = use newData
                    }
    
                    if (!check)
                    {
                        string mgs = newData[3];
    
                        if (mgs.Substring(8, 1) == "f")
                        {
                            for (int j = 0; j < newData.Length; j++)
                            {
                                oldData[j] = newData[j];
                            }
                            
                            for (int i = 0; i < IDList.Items.Count; i++)
                            {
                                if (oldData[0] == IDList.Items[i].ToString().ToLower())
                                {
                                    dataGridView1.Rows.Add(oldData);
                                    SmsRtb.Text = "The job name is : " + oldData[1] + '\n' + "message: " + oldData[3] + '\n' + "Date: " + oldData[5] + '\n' + "Time: " + oldData[6];
    
                                    //SendSMS();
    
                                }
                            }
    
                        }
                    }
            }
