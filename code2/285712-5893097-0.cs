            private static void CreateZipFromText(string text)
        {            
            byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(text);
            string encodedText = Convert.ToBase64String(byteArray);
            FileStream destFile = File.Create("C:\\temp\\testCreated.zip");
            byte[] buffer = Encoding.UTF8.GetBytes(encodedText);
            MemoryStream memoryStream = new MemoryStream();
            
            using (System.IO.Compression.GZipStream gZipStream = new System.IO.Compression.GZipStream(destFile, System.IO.Compression.CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }
        }
		
