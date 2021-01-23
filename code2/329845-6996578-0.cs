            StringBuilder source = new StringBuilder();
            for (int ix = 0; ix < 224; ix++)
            {
                source.Append((char)(ix + 32));
            }
            EncodingInfo[] encs = Encoding.GetEncodings();
            foreach (var encInfo in encs)
            {
                System.Console.WriteLine(encInfo.DisplayName);
                Encoding enc = Encoding.GetEncoding(encInfo.CodePage);
                var result = enc.GetBytes(source.ToString().ToCharArray());
                for (int ix = 0; ix < 224; ix++)
                {
                    if (result[ix] == 63 && source[ix] != 63)
                    {
                        // Code page translated character to '?'
                        System.Console.Write("{0:d}", source[ix]);
                    }
                }
                System.Console.WriteLine();
            }
