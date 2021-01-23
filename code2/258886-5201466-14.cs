    int oldLine = 0;
        using (FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None))
        {
                foreach (int lineNo in lineNos)
                {
                    position = (lineNo - oldLine -1) * LineLength;
                    fs.Seek(position, SeekOrigin.Current);
                    line = ReadLine(fs, LineLength);
                    Console.WriteLine("{0}\t\t\t{1}\t\t\t\t{2}", lineNo, position, line);
                    oldLine = lineNo;
                }
        }
