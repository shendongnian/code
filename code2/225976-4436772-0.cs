     using (FileStream streamWriter = File.Create(targetDirectory + fileName))
        {
           int size = data.Length;
           byte[] data = new byte[size];
           while (true)
           {
                size = s.Read(data, 0, data.Length);
                if (size > 0)
                {
                    streamWriter.Write(data, 0, size);
                }
                else
                {
                   break;
                }
           }
        }
