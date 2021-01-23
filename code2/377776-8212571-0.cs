     public static void Compress(FileInfo sourceFile, string destinationFileName,string destinationTempFileName)
            {
                Crc32 crc = new Crc32();
                string zipFile = Path.Combine(sourceFile.Directory.FullName, destinationTempFileName);
                zipFile = Path.ChangeExtension(zipFile, ZIP_EXTENSION);
    
                using (FileStream fs = File.Create(zipFile))
                {
                    using (ZipOutputStream zOut = new ZipOutputStream(fs))
                    {
                        zOut.SetLevel(9);
                        ZipEntry entry = new ZipEntry(ZipEntry.CleanName(destinationFileName));
    
                        entry.DateTime = DateTime.Now;
                        entry.ZipFileIndex = 1;
                        entry.Size = sourceFile.Length;
    
                        using (FileStream sourceStream = sourceFile.OpenRead())
                        {
                            crc.Reset();
                            long len = sourceFile.Length;
                            byte[] buffer = new byte[bufferSize];
                            while (len > 0)
                            {
                                int readSoFar = sourceStream.Read(buffer, 0, buffer.Length);
                                crc.Update(buffer, 0, readSoFar);
                                len -= readSoFar;
                            }
                            entry.Crc = crc.Value;
                            zOut.PutNextEntry(entry);
    
                            len = sourceStream.Length;
                            sourceStream.Seek(0, SeekOrigin.Begin);
                            while (len > 0)
                            {
                                int readSoFar = sourceStream.Read(buffer, 0, buffer.Length);
                                zOut.Write(buffer, 0, readSoFar);
                                len -= readSoFar;
                            }
                        }
                        zOut.Finish();
                        zOut.Close();
                    }
                    fs.Close();
                }
            }
