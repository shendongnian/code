        private void FileCopy(string strCopyFile, string strCopyFileTo)
        {
            try
            {
                File.Copy(strCopyFile, strCopyFileTo);
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message,Critical);
            }
        }
    
