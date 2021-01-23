    public void Split(string inputfile, string outputfilesformat)
    {
       
        System.IO.StreamWriter outfile = null;
        string line;
        string[] splitArray;
        string nameFromFile = "";
        try
        {
            using (var infile = new System.IO.StreamReader(inputfile))
            {
                while (!infile.EndOfStream)
                {
                    line = infile.ReadLine();
                    splitArray = line.Split(new char[] { ',' });
                    if (!splitArray[0].StartsWith("\"#"))
                    {
                        if (splitArray[4].Replace("\"", "") != nameFromFile.Replace("\"", ""))
                        {
                            if (outfile != null)
                            {
                                outfile.Dispose();
                                outfile = null;
                            }
                            nameFromFile = splitArray[4].Replace("\"", "");
                            continue;
                        }
                        if (outfile == null)
                        {
                            outfile = new System.IO.StreamWriter(
                                string.Format(outputfilesformat, nameFromFile),
                                false,
                                infile.CurrentEncoding);
                        }
                        outfile.WriteLine(line);
                    }
                }
            }
        }
        finally
        {
            if (outfile != null)
                outfile.Dispose();
        }
    }
