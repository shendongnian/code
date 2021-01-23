    static void PublishWorkbook(string LocalPath, string SharePointPath)
    {
        WebResponse response = null;
    
        try
        {
            // Create a PUT Web request to upload the file.
            WebRequest request = WebRequest.Create(SharePointPath);
    
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "PUT";
    
            // Allocate a 1K buffer to transfer the file contents.
            // The buffer size can be adjusted as needed depending on
            // the number and size of files being uploaded.
            byte[] buffer = new byte[1024];
    
            // Write the contents of the local file to the
            // request stream.
            using (Stream stream = request.GetRequestStream())
            using (FileStream fsWorkbook = File.Open(LocalPath,
                FileMode.Open, FileAccess.Read))
            {
                int i = fsWorkbook.Read(buffer, 0, buffer.Length);
    
                while (i > 0)
                {
                    stream.Write(buffer, 0, i);
                    i = fsWorkbook.Read(buffer, 0, buffer.Length);
                }
            }
    
            // Make the PUT request.
            response = request.GetResponse();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            response.Close();
        }
    }
