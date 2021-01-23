    GsmCommMain comm = new GsmCommMain(COMPort.ToString(), 9600, 500);
    try{ for (int i = 0; i < dtObj.Rows.Count; i++)
                                        {
                                            if (dtObj.Rows[i]["smsNumber"] != null)
                                            {
                                                if (dtObj.Rows[i]["smsNumber"].ToString() != "")
                                                {
                                                    if (dtObj.Rows[i]["status"].ToString() != "Sent")
                                                    {
                                                        Thread.Sleep(Convert.ToInt32("50000"));
                                                        string txtMessage = dtObj.Rows[i]["sms"].ToString();
                                                        string txtDestinationNumbers = dtObj.Rows[i]["smsNumber"].ToString();
                                                        bool unicode = true;
                                                        SmsSubmitPdu[] pdu = SmartMessageFactory.CreateConcatTextMessage(txtMessage, unicode, txtDestinationNumbers);
                                                        comm.SendMessages(pdu);
                                                        obj_bal_ForAll.bal_forAll_Delete("tbl_SMS", "smsId", dtObj.Rows[i]["smsId"].ToString());
                                                    }
                                                }
                                            }
                                        }
                                        if (comm.IsOpen())
                                        {
                                            comm.Close();
                                        }  
										}catch(Exception ex){if (comm.IsOpen()){comm.Close();}}
