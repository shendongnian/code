                   private void MessageCallBack(IAsyncResult aResult)
                    {  
                     try
                    {
                        int size = sck.EndReceiveFrom(aResult, ref epRemote);
                        if(size>0)
                        {
                            byte[] receivedData = new byte[1500];
                            receivedData = (byte[])aResult.AsyncState;
                            ASCIIEncoding eEncoding = new ASCIIEncoding();
                            string receivedMessage = eEncoding.GetString(receivedData);
                            listBox1.Invoke(new MethodInvoker(delegate { 
                        listBox1.Items.Add("From a friend: " + receivedMessage); }));
                        }
                        byte[] buffer = new byte[1500];
                        sck.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, 
                    ref epRemote, new AsyncCallback(MessageCallBack), buffer);
                    }
                    catch(Exception exp)
                    { /* here is the solution, when the Catch is triggered, close the 
                      socket and recreate it to avoid the issues that I been having of 
                      not sending messages and instability. I also added some functions 
                      that would keep sending the status and //being checked on the other 
                      side in order to keep online/offline status.*/
                        sck.Close();
                        sck = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 
                         ProtocolType.Udp);
                        sck.SetSocketOption(SocketOptionLevel.Socket, 
                         SocketOptionName.ReuseAddress, true);
                        connectEndPoint();
                        //MessageBox.Show("Exception Small Chat: " + exp.ToString());
                    }
        }
 
