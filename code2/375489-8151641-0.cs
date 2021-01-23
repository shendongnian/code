        public static void Decompress(string outputDirectory, string zipFile)
        {
            try
            {
                if (!File.Exists(zipFile))
                    throw new FileNotFoundException("Zip file not found.", zipFile);
                Package zipPackage = ZipPackage.Open(zipFile, FileMode.Open, FileAccess.Read);
                foreach (PackagePart part in zipPackage.GetParts())
                {
                    string targetFile = outputDirectory + "\\" + part.Uri.ToString().TrimStart('/');
                    using (Stream streamSource = part.GetStream(FileMode.Open, FileAccess.Read))
                    {
                        using (Stream streamDestination = File.OpenWrite(targetFile))
                        {
                            Byte[] arrBuffer = new byte[10000];
                            int iRead = streamSource.Read(arrBuffer, 0, arrBuffer.Length);
                            while (iRead > 0)
                            {
                                streamDestination.Write(arrBuffer, 0, iRead);
                                iRead = streamSource.Read(arrBuffer, 0, arrBuffer.Length);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
