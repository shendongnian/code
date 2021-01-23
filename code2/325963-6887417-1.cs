     protected void btnUpload_Click(object sender, EventArgs e)
        {
            string file = FileUpload1.FileName;
            RESTService1Client client = new RESTService1Client();
            byte[] bytearray = null;
            string name = "";
            if (FileUpload1.HasFile)
            {
                name = FileUpload1.FileName;
                Stream stream = FileUpload1.FileContent;
                stream.Seek(0, SeekOrigin.Begin);
                bytearray = new byte[stream.Length];
                int count = 0;
                while (count < stream.Length)
                {
                    bytearray[count++] = Convert.ToByte(stream.ReadByte());
                }
            }  
            WebClient wclient = new WebClient();
            wclient.Headers.Add("Content-Type", "image/jpeg");
            client.uploadImage(FileUpload1.FileContent, Path.GetFileName(name));
    }
