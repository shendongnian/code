            var pattern = @"(<input)(.*?)(>)";
            var options = RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
            
            var input = item.GetHtmlInput();
            var matStems = new Queue<Tuple<string, int>>();
            var matches = Regex.Matches(input, pattern, options);
            
            var currentStringPosition = 0;
            
            foreach (Match m in matches)
            {
                if(m.Index == 0)
                {
                    var leadingStem = new Tuple<string, int>("", -1);
                    matStems.Enqueue(leadingStem);
                }
                
                var doc = new HtmlDocument();
                doc.LoadHtml(m.Value);
                var inputElement = doc.DocumentNode.SelectNodes("//input").LastOrDefault();
                var inputResponseId = inputElement.Attributes["data-id"].Value;
                
                var endingIndex = m.Index + m.Length;
                var stemLength = m.Index - currentStringPosition;
                var stemContent = input.Substring(currentStringPosition, stemLength);
                
                var stemToAdd = new Tuple<string, int>(stemContent, Convert.ToInt32(inputResponseId));
                
                matStems.Enqueue(stemToAdd);
                currentStringPosition = endingIndex;
                if (endingIndex != input.Length) continue;
                var laggingStem = new Tuple<string, int>("", -1);
                matStems.Enqueue(laggingStem);
            }
