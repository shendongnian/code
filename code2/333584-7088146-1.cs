        private void processCSV(string inputFileName)
        {
            Regex regexObj = new Regex(@"\s*(?:""(?<val>""[^""]*(""""[^""]*)*"")\s*|(?<val>[^,]*))(?:,|$)");
            List<List<Match>> elements = File.ReadAllLines(inputFileName)
                .Select<string,List<Match>>(x=>regexObj.Matches(x).Cast<Match>().ToList()).ToList();            
            List<string> newLines = elements.Select(y=>y.Select(z=>z.Groups["val"].Value).ToList())
                                            .Select(z=>string.Format("{0},{1},{2},{3}",z[0],z[1],z[2],z[4]+z[5]))
                                            .ToList();
                
             //Write newlines somewhere
        }
