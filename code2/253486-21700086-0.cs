            string OPC_url_Simatic = ConfigurationManager.AppSettings["ServerId"].ToString();
                
                
                ObjConnectInfo.LocalId = "en";
                ObjConnectInfo.KeepAliveTime = 5000;
                ObjConnectInfo.RetryAfterConnectionError = true;
                ObjConnectInfo.RetryInitialConnection = true;
                bool connectFailed = false;
                ///define a client handle
                int clientHandle = 1;
                //Try to connect with the API connect method:
                try
                {
                    ObjDaServerMgt.Connect(OPC_url_Simatic, clientHandle, ref ObjConnectInfo, out connectFailed);
                }
                catch (Exception ex)
                {
                   // MessageBox.Show("Handled Connect exception. Reason: " + ex.Message);.
                    log.Error(ex.ToString());
                    // Make sure following code knows connection failed:
                    connectFailed = true;
                }
                // Handle result:
                if (connectFailed)
                {
                    // Tell user connection attempt failed:
                    //MessageBox.Show("Connect failed");
                    log.Error("Connection Failed");
                }
