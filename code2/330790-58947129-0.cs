            try
            {
                // Setup session options
                SessionOptions sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Ftp,
                    HostName = hostName,
                    UserName = userName,
                    Password = password,
                };
                if (protocal.ToLower() == "ftp")
                {
                    sessionOptions.Protocol = Protocol.Ftp;
                    sessionOptions.FtpSecure = FtpSecure.Implicit;
                    sessionOptions.TlsHostCertificateFingerprint = ftpHostKeyFingerprint;// ;
                    //we cannot set GiveUpSecurityAndAcceptAnySshHostKey=true in case of FTP and WEBDAV, Its mandatory to pass SshHostKeyFingerprint Key value.
                 
                }
                else if (protocal.ToLower() == "sftp")
                {
                    sessionOptions.Protocol = Protocol.Sftp;
                    //we can set GiveUpSecurityAndAcceptAnySshHostKey=true in case of SFTP and SCP, Its not mandatory to pass SshHostKeyFingerprint Key value.
                    if (string.IsNullOrEmpty(ftpHostKeyFingerprint))
                    {
                        sessionOptions.GiveUpSecurityAndAcceptAnySshHostKey = true;
                    }
                    else
                    {
                        sessionOptions.SshHostKeyFingerprint = ftpHostKeyFingerprint;
                    }
                }
                else if (protocal.ToLower() == "scp")
                {
                    sessionOptions.Protocol = Protocol.Scp;
                   
                    if (string.IsNullOrEmpty(ftpHostKeyFingerprint))
                    {
                        sessionOptions.GiveUpSecurityAndAcceptAnySshHostKey = true;
                    }
                    else
                    {
                        sessionOptions.SshHostKeyFingerprint = ftpHostKeyFingerprint;
                    }
                }
               
                if (string.IsNullOrWhiteSpace(searchPattern))
                {
                    searchPattern = "";
                }
                using (Session session = new Session())
                {
                    session.Open(sessionOptions);
                    // Download files
                    TransferOptions transferOptions = new TransferOptions();
                    transferOptions.TransferMode = TransferMode.Binary;
                    TransferOperationResult transferResult;
                    transferResult = session.GetFiles(SFTPSourcePath + searchPattern, LocalDestinationPath, false, transferOptions);
                    transferResult.Check(); // Throw on any error
                    _prTasksPRPayStubLogger.Info($"Files fetched from FTP - { transferResult.Transfers.Count}");
                    var archivePath = Path.Combine(SFTPSourcePath, "Archive");
                    foreach (TransferEventArgs transfer in transferResult.Transfers)
                    {
                        //Move Files
                        var destinationFileName = archivePath + "/Archive_" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetFileName(transfer.FileName);
                        session.MoveFile(transfer.FileName, destinationFileName);
                    }
                }
            }
            catch (Exception e)
            {
               //
            }
        
