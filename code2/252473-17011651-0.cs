                System.Drawing.Imaging.ImageFormat ImageFormat = imageToConvert.RawFormat;
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, ImageFormat);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
