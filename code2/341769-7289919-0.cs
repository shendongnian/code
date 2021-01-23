            var reader = File.OpenText(infile);
            string outFileName = "file{0}.txt";
            int outFileNumber = 1;
            const int MAX_LINES = 300;
            while (!reader.EndOfStream)
            {
                var writer = File.CreateText(string.Format(outFileName, outFileNumber++));
                for (int idx = 0; idx < MAX_LINES; idx++)
                {
                    writer.WriteLine(reader.ReadLine());
                    if (reader.EndOfStream) break;
                }
                writer.Close();
            }
            reader.Close();
