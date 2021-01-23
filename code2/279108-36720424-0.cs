    public static bool CreateFile()
        {
            // Create file in memory
            UnicodeEncoding uniEncoding = new UnicodeEncoding();
            // Create the data to write to the stream.
            byte[] memstring = uniEncoding.GetBytes("you're file content here");
            using (MemoryStream memStream = new MemoryStream(100))
            {
                // Write the first string to the stream.
                memStream.Write(memstring, 0, memstring.Length);
                // upload to s3
                // close connections
                try
                {
                    AmazonS3Client s3 = new AmazonS3Client(RegionEndpoint.USEast1);
                    using (Amazon.S3.Transfer.TransferUtility tranUtility =
                                  new Amazon.S3.Transfer.TransferUtility(s3))
                    {
                        tranUtility.Upload(memStream, bucketname, keyname);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
