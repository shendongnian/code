            var writer = File.OpenWrite("test.txt");
            using (writer)
            {
                if (writer.CanWrite)
                {
                    byte[] buffer = null;
                    //...
                    writer.Write(buffer, 0, buffer.Length);
                }
            }
