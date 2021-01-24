               float[] myArray = {0.0f, 0.0f, 0.0f};
               int len = myArray.Length;
               List<byte> bytes = new List<byte>();
               foreach (float f in myArray)
               {
                   byte[] t = System.BitConverter.GetBytes(f);
                   bytes.AddRange(t);
               }
               byte[] byteArray = bytes.ToArray();
