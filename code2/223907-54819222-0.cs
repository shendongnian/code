        public static string ReadAllTextFromFile(string file)
        {
            const int WindowsCodepage1252 = 1252;
            string text;
            try
            {
                var utf8Encoding = Encoding.UTF8;
                utf8Encoding.DecoderFallback = DecoderFallback.ExceptionFallback;
                text = File.ReadAllText(file, utf8Encoding);
            }
            catch (DecoderFallbackException dfe)//then text is not entirely valid UTF8, contains Codepage 1252 characters that can't be correctly decoded to UTF8
            {
                var codepage1252Encoding = Encoding.GetEncoding(WindowsCodepage1252, EncoderFallback.ExceptionFallback, DecoderFallback.ExceptionFallback);
                text = File.ReadAllText(file, codepage1252Encoding);
            }
            return text;
        }
