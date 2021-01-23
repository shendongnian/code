     String[] files = System.IO.Directory.GetFiles(fbd.SelectedPath, "*.txt" , System.IO.SearchOption.AllDirectories);
 
                foreach (var file in files)
                {
                       
                        byte[] ansiBytes;
                        using (var reader = new System.IO.StreamReader(file, true))
                        {
                                 ansiBytes = File.ReadAllBytes(file);
                        }
                        if (!IsUTF8Bytes(ansiBytes))
                        {
                            System.IO.File.Move(file, file + "_");
                            var utf8String = Encoding.Default.GetString(ansiBytes);
                            File.WriteAllText(file, utf8String);
                        }
 
                }
           
             
       
 
        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1;
            byte curByte;
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("Error byte format");
            }
            return true;
        }
