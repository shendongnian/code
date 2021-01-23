    private static void Transfer(object obj)
    {
        frmMain frmPar = (frmMain)obj;
        try
        {    
            string filename=_strStartingPath + @"\" + _strZipFileName + ".zip";
            FileInfo fileInf = new FileInfo(filename);
            string uri = _strFtpAddress + "/" + fileInf.Name;
            FtpWebRequest reqFTP;
            // Create FtpWebRequest object from the Uri provided
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            // Provide the WebPermission Credintials
            reqFTP.Credentials = new NetworkCredential(_strFtpUserName, _strFtpPassword);
            // By default KeepAlive is true, where the control connection is 
            // not closed after a command is executed.
            reqFTP.KeepAlive = false;
            // Specify the command to be executed.
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            // Specify the data transfer type.
            reqFTP.UseBinary = true;
            // Notify the server about the size of the uploaded file
            reqFTP.ContentLength = fileInf.Length;
            // The buffer size is set to 2kb
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded
            FileStream fs = fileInf.OpenRead();
   
            // Stream to which the file to be upload is written
            Stream strm = reqFTP.GetRequestStream();
    
            // Read from the file stream 2kb at a time
            contentLen = fs.Read(buff, 0, buffLength);
            frmPar.prbSendata.Control.Invoke((MethodInvoker)(() =>{
                frmPar.prbSendata.Minimum=0;
                frmPar.prbSendata.Maximum=100;
            }));
    
            // Till Stream content ends
            long loadSize=0;
            while (contentLen != 0)
            {
                // Write Content from the file stream to the FTP Upload Stream
                loadSize+=contentLen;
                frmPar.prbSendata.Control.Invoke((MethodInvoker)(() =>{
                    frmPar.prbSendata.Value=(int)(loadSize*100/fileInf.Length);
                    }));
                strm.Write(buff, 0, contentLen);
                contentLen = fs.Read(buff, 0, buffLength);
            }
    
            // Close the file stream and the Request Stream
            strm.Close();
            fs.Close();
        }
        catch (Exception err)
        {
            MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        frmPar.txtResult.Invoke((MethodInvoker)(() =>frmPar.Cursor = Cursors.Default));
    }
