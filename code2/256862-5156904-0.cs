    public static BIO GetInFile(string infile)
    {
        BIO bio;
        if (string.IsNullOrEmpty(infile))
        {
                bio = BIO.MemoryBuffer();
                Stream cin = Console.OpenStandardInput();
                byte[] buf = new byte[1024];
                while (true)
                {
                        int len = cin.Read(buf, 0, buf.Length);
                        if (len == 0)
                                break;
                        bio.Write(buf, len);
                }
                return bio;
        }
        return BIO.File(infile, "r");
    }            
