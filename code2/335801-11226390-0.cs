                    // Check each Availble COM port
                    foreach (string l_sport in l_available_ports)
                    {
                        GlobalVars.g_serialport = GlobalFunc.OpenPort(l_sport, Convert.ToInt32(this.cboBaudRate.Text), Convert.ToInt32(this.cboDataBits.Text), Convert.ToInt32(this.txtReadTimeOut.Text), Convert.ToInt32(this.txtWriteTimeOut.Text));
                        if (GlobalVars.g_serialport.IsOpen)
                        {
                            GlobalVars.g_serialport.WriteLine("AT\r");
                            Thread.Sleep(500);
                            string l_response = GlobalVars.g_serialport.ReadExisting();
                            if (l_response.IndexOf("OK") >= 0)
                            {
                                GlobalVars.g_serialport.WriteLine("AT+CMGF=1\r");
                                Thread.Sleep(500);
                                string l_response1 = GlobalVars.g_serialport.ReadExisting();
                                if (l_response1.IndexOf("OK") >= 0)
                                {
                                    GlobalVars.g_PhoneNo = txt_PhNum.Text;
                                    MessageBox.Show("Connected Successfully", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lblConnectionStatus.Text = "Phone Connected Successfully.";
                                    btnOK.Enabled = false;
                                    btnDisconnect.Enabled = true;
                                    GlobalVars.g_serialport.WriteLine("AT+CGSN\r");
                                    Thread.Sleep(500);
                                    string l_imei = GlobalVars.g_serialport.ReadExisting();
                                    Console.WriteLine("Modem IMEI:" + l_imei);
                                    if (l_imei.IndexOf("OK", 1) > 0)
                                    {
                                        l_imei = l_imei.Replace("AT+CGSN\r\r\n", null);
                                        l_imei = l_imei.Replace("\r\n\r\nOK\r\n", null);
                                        lbl_ModemIMEI.Text = l_imei;
                                    }
                                    else
                                    {
                                        lblConnectionStatus.Text = "Phone Connected Successfully. Error reading IMEI.";
                                    }
                                    EnableSMSNotification(GlobalVars.g_serialport);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("No AT+CMGF cmd response");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No AT cmd response");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Phone At:" + l_sport);
                        }
                    }
