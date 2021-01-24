     public void ImportStream(Stream data)
        {
            if (data.ReadByte() != -1)
            {    
                data.Seek(0, SeekOrigin.Begin);            
                using (var reader = new StreamReader(data))
                {                               
                    string textRead = reader.ReadToEnd();
                }
            }
    }
