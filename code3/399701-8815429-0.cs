      public Bitmap ConstructBitmap(System.IO.Stream stream, int sideSize)
        {
            try
            {
                LogMessageToFile("Hello Stream");
                XyzFileDefinition file = new XyzFileDefinition(stream);
                using (MemoryStream mstream = new MemoryStream(Convert.FromBase64String(file.EncodedImage)))
                {
                    LogMessageToFile("using Stream");
                    Bitmap bmp = new Bitmap(mstream);
                    LogMessageToFile(bmp.ToString());
                    return bmp;
                }
            }
            catch (Exception ex)
            {
                LogMessageToFile(ex.ToString());
                throw;
            }
            finally 
            {
                stream.Close();
            }
        }
