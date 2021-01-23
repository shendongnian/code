    private void AsyncPipeCallback(IAsyncResult Result)  
    {   
    	try  
    	{  
    		pipeServer.EndWaitForConnection(Result);  
                sr = new StreamReader(pipeServer);
    
                        //string message = sr.ReadToEnd();
                        bWait = false;
                        cbRequestBytes = BUFFER_SIZE;
    
    
    
    
    
    
                        string pipeData = string.Empty;
    
                        pipeData = sr.Read(bRequest, 0, 255).ToString().Trim();
                        strMessage = new string(bRequest);
    
    
    
    
                        strMessage = strMessage.Replace("\0", string.Empty);
                        if (strMessage.Contains("Aborted"))
                        {
    
    
                            if (pipeServer.IsConnected)
                            {
                                pipeServer.Flush();
                                pipeServer.Disconnect();
                            }
                            break;
                        }
                        else
                            if (strMessage.Contains("Completed"))
                            {
                                if (progressBar1.InvokeRequired)
                                {
                                    strPercent = "100%";
                                }
    
    
                                if (pipeServer.IsConnected)
                                {
                                    pipeServer.Flush();
                                    pipeServer.Disconnect();
                                }
                                this.bComplete = true;
                                break;
                            }
                        // 26 dec 2011 Comment code //////
                        if (strMessage == "")
                        {
                            progressBar1.Visible = false;
                            progressBar2.Visible = true;
                        }
                        else
                        {
                            progressBar1.Visible = true;
                            progressBar2.Visible = false;
                        }
    
                        //// 26 dec 2011 Comment code //////
    
                        string[] strStatusMessages = strMessage.Trim().Split(',');
    
    
    
                        // 26 dec 2011 Comment code //////
                        pipeServer.Flush();
    
                        pipeServer.Disconnect();
    	}  
    	catch { }
        if(Running)
            pipeServer.BeginWaitForConnection(myCallback, null); 
    } 
