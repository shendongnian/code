                int maxValue = Int32.MaxValue / 50;
                int[] myIntArray = Enumerable.Range(0, maxValue).ToArray();
                var path = "e:\\temp\\1.test";
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
                {
                    int intLength = myIntArray.Length;
                    writer.Write(intLength);
    
                    byte[] bytes = new byte[intLength * sizeof(int)];
                    Buffer.BlockCopy(myIntArray, 0, bytes, 0, sizeof(byte));
                    writer.Write(bytes);
                }
