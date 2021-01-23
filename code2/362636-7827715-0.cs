      string filePath = uploadFile(fileUploadControl.FileContent);
    private string uploadFile(Stream serverFileStream)
    {
        string filename = ConfigurationManager.AppSettings["FileUploadTempDir"] + 
        DateTime.Now.ToString("yyyyMMddhhmm") + "_" + 
        Customer.GetCustomerName(CustomerId).Replace(" ", "_") + ".txt";
       try
       {
        int length = 256;
        int bytesRead = 0;
        Byte[] buffer = new Byte[length];
        // write the required bytes
        using (FileStream fs = new FileStream(filename, FileMode.Create))
        {
            do
            {
                bytesRead = serverFileStream.Read(buffer, 0, length);
                fs.Write(buffer, 0, bytesRead);
            }
            while (bytesRead == length);
        }
        serverFileStream.Dispose();
        return filename;
      }
      catch (Exception ex)
      {
        lblErrorMessage.Text += "An unexpeded error occured uploading the file. " + ex.Message;
        return string.Empty;
      }
    }
