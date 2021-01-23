    public string ShortenLineLengthForEachParagraph(string origMsg, int maxLineLength)
        {
            StringBuilder sb = new StringBuilder();
            string[] paragraphs = origMsg.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
            foreach (var paragraph in paragraphs)
            {
                sb.AppendLine(ShortenLineLength(paragraph,maxLineLength));
            }
            return sb.ToString();
        }
        private string ShortenLineLength(string origMsg, int maxLineLength)
        {
            StringBuilder sb = new StringBuilder();
            string[] words = origMsg.Split(' ');
            int currLineLength = 0;
            foreach (string word in words)
            {
                if (currLineLength + word.Length + 1 < maxLineLength) // +1 accounts for adding a space
                {
                    if (currLineLength == 0)
                    {
                        sb.Append(word);
                        currLineLength = currLineLength + word.Length;
                    }
                    else
                    {
                        sb.AppendFormat(" {0}", word);
                        currLineLength = currLineLength + word.Length + 1; // +1 accounts for adding a space
                    }
                    
                }
                else
                {
                    sb.AppendFormat("{0}{1}", Environment.NewLine, word);
                    currLineLength = word.Length;
                }
            }
            return sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        }
