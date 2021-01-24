byte[] encryptionKey = null;
byte[] macInitialVector = null;
...
using (var conn = new SqlConnection(ConnectionString))
            using (var cmd = new SqlCommand(uploadedFileQuery, conn))
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FileServiceMessageEnvelope readAllEnvelope = null;
                    var originalFileName = reader["UploadedFileClientName"].ToString();
                    var fileId = Convert.ToInt64(reader["UploadedFileId"].ToString());
                    //var originalFileExtension = originalFileName.Substring(originalFileName.IndexOf('.'));
                    //_logger.LogStatement($"Scooped extension: {originalFileExtension}", LogLevel.Trace);
                    envelopes.Add(readAllEnvelope = new FileServiceMessageEnvelope
                    {
                        ActionType = FileServiceActionTypeEnum.ReadAll,
                        FileType = FileTypeEnum.UploadedFile,
                        FileName = reader["UploadedFileServerName"].ToString(),
                        FileId = fileId,
                        WorkerAuthorization = null,
                        BinaryTimestamp = DateTime.Now.ToBinary(),
                        Position = 0,
                        Count = Convert.ToInt32(reader["UploadedFileSize"]),
                        SignerFqdn = _messengerConfig.FullyQualifiedDomainName
                    });
                    readAllEnvelope.SignMessage(_messengerConfig.PrivateKeyBytes, _messengerConfig.PrivateKeyPassword);
                    signedPayload = new SecureMessage { Payload = new byte[0] };
                    signedPayload.SignMessage(_messengerConfig.PrivateKeyBytes, _messengerConfig.PrivateKeyPassword);
                    signedPayloadBytes = SerializationHelper.SerializeObjectToBuffer(signedPayload);
                    encryptionKey = (byte[])reader["UploadedFileEncryptionKey"];
                    macInitialVector = (byte[])reader["UploadedFileEncryptionMacInitialVector"];
                }
                conn.Close();
            }
Eagle-eyed observers might realize that I have not properly coupled the `encryptionKey` and `macInitialVector` to the correct record, since each file has a unique key and vector. This means I was using the key for **one** of the files to decrypt **all of them** which is why they were all corrupt except for one file -- they were not properly decrypted. I solved this issue by coupling them together with the ID in a simple POCO and retrieving the appropriate key and vector for each file upon decryption.
