                string pattern = "begin=\"(?'begin'[^\"]+)";
                string stream = "stream<?xpacket begin=\"ï»¿\" id=\"W5M0MpCehiHzreSzNTczkc9d\"?>";
                Match match = Regex.Match(stream, pattern);
                string begin = match.Groups["begin"].Value;
                byte[] beginBytes = Encoding.Unicode.GetBytes(begin);
