    class Program
    {
        public static string DecodeQuotedPrintable(string input, string charSet)
        {
            Encoding enc;
            try
            {
                enc = Encoding.GetEncoding(charSet);
            }
            catch
            {
                enc = new UTF8Encoding();
            }
            var occurences = new Regex(@"(=[0-9A-Z]{2}){1,}", RegexOptions.Multiline);
            var matches = occurences.Matches(input);
            foreach (Match match in matches)
            {
                try
                {
                    byte[] b = new byte[match.Groups[0].Value.Length / 3];
                    for (int i = 0; i < match.Groups[0].Value.Length / 3; i++)
                    {
                        b[i] = byte.Parse(match.Groups[0].Value.Substring(i * 3 + 1, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
                    }
                    char[] hexChar = enc.GetChars(b);
                    input = input.Replace(match.Groups[0].Value, new String(hexChar));
                }
                catch
                { ;}
            }
            input = input.Replace("?=", "");
            return input;
        }
        static void Main(string[] args)
        {
            string sData = @"*** Hello, World *** =0D=0AURl: http://www.example.com?id=3D=27a9dca9-5d61-477c-8e73-a76666b5b1bf=0D=0A=0D=0A  
    Name: Hello World=0D=0A
    Phone: 61234567890=0D=0A
    Email: hello@test.com=0D=0A=0D=0A";
            
            Console.WriteLine(DecodeQuotedPrintable(sData,"utf-8"));
            Console.ReadLine();
        }
    }
