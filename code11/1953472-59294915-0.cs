                               try
                                {
                                    var DecryptedInfo = FileCryptoDecryptor.ReadEncryptedConfiguration("hakuna.xml.aes", Global_Variables.AppPassword);
                                    string DecryptedFTPPass = EncryDecryptor.Decrypt(DecryptedInfo.FtpPassword, "blablabla");
                                    token.ThrowIfCancellationRequested();
                                    return General_Functions.isValidConnection(info.HDSynologyIP, info.FtpUsername, DecryptedFTPPass);
                                }
                                catch (Exception ex) when (!(ex is OperatiomCanceledException))
                                {
                                    MessageBox.Show(ex.ToString());
                                }
