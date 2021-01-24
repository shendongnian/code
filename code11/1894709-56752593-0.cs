            static void Main(string[] args)
            {
                string input = "<emptyElement/>";
                string patternNullTag = @"\<(?'tagname'\w+)/\>";
                string output = Regex.Replace(input, patternNullTag, ReplaceNullElement);
            }
            static string ReplaceNullElement(Match match)
            {
                string tagname = match.Value.Replace("<", "").Replace("/>", "");
                string newElement = "<" + tagname + ">" + "</" + tagname + ">";
                return newElement;
            }
