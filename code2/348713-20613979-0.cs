        private static List<string> fileUploadRequestParser(Stream stream)
        {
            //-----------------------------111111111111111
            //Content-Disposition: form-data; name="file"; filename="data.txt"
            //Content-Type: text/plain
            //...
            //...
            //-----------------------------111111111111111
            //Content-Disposition: form-data; name="submit"
            //Submit
            //-----------------------------111111111111111--
            List<String> lstLines = new List<string>();
            TextReader textReader = new StreamReader(stream);
            string sLine = textReader.ReadLine();
            Regex regex = new Regex("(^-+)|(^content-)|(^$)|(^submit)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline);
            
            while (sLine != null)
            {
                if (!regex.Match(sLine).Success)
                {
                    lstLines.Add(sLine);
                }
                sLine = textReader.ReadLine();
            }
            return lstLines;
        }
