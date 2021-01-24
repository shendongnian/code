            int byteSize = 16;
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[byteSize]; // in this buffer I'm saving the 16 bytes read
                while (fs.Read(buffer, 0, byteSize) > 0)
                {
                    string temp = System.Text.RegularExpressions.Regex.Replace(ByteArrayToHexViaLookup32(buffer), ".{2}", "$0 ");
                    Console.WriteLine(temp);
                }
            }
