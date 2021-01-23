        using (System.IO.StreamReader sr = new System.IO.StreamReader(inputStream))
        {
            string line;
            while (!string.IsNullOrEmpty(line = sr.ReadLine()))
            {
                // do whatever you need to with the line
            }
        }
