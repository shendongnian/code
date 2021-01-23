            string pathSource = @"c:\tests\source.txt";
            using (FileStream fsSource = new FileStream(pathSource,
                FileMode.Open, FileAccess.Read))
            {
                // Read the source file into a byte array.
                byte[] bytes = new byte[10];
                int numBytesToRead = 10;
                int numBytesRead = 50;
                // Read may return anything from 0 to numBytesToRead.
                int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);
            }
