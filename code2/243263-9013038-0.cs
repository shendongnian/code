      private string BlobToString(BlobColumn blob)
        {
            string result = "";
            try
            {
                if (blob != null)
                {
                    result = System.Text.Encoding.Unicode.GetString(blob.GetBlobData(0, Convert.ToInt32(blob.Length)));
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }
