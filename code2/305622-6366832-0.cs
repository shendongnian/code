    public static Encoding GetFileEncoding(string srcFile)
    {
     // *** Use Default of Encoding.Default (Ansi CodePage)
                Encoding encoding = Encoding.Default;
                using (FileStream stream = File.OpenRead(fileName))
                {
                    // *** Detect byte order mark if any - otherwise assume default
                    byte[] buff = new byte[5];
                    stream.Read(buff, 0, buff.Length);
                    if (buff[0] == 0xEF && buff[1] == 0xBB && buff[2] == 0xBF)
                    {
                        encoding = Encoding.UTF8;
                    }
                    else if (buff[0] == 0xFE && buff[1] == 0xFF)
                    {
                        encoding = Encoding.BigEndianUnicode;
                    }
                    else if (buff[0] == 0xFF && buff[1] == 0xFE)
                    {
                        encoding = Encoding.Unicode;
                    }
                    else if (buff[0] == 0 && buff[1] == 0 && buff[2] == 0xFE && buff[3] == 0xFF)
                    {
                        encoding = Encoding.UTF32;
                    }
                    else if (buff[0] == 0x2B && buff[1] == 0x2F && buff[2] == 0x76)
                    {
                        encoding = Encoding.UTF7;
                    }
                }
                return encoding;
    }
