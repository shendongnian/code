    public class WordProcessing
    {
        static public string WordEllipsis(string text, int maxLength, string ellipsis = "...")
        {
            string result;
            if (text.Length <= maxLength)
            {
                result = text;
            }
            else if (maxLength <= ellipsis.Length)
            {
                result = ellipsis.Substring(0, maxLength);
            }
            else
            {
                result = text.Substring(0, maxLength - ellipsis.Length);
                var lastWordPosition = result.LastIndexOf(' ');
                if (lastWordPosition < 0)
                {
                    lastWordPosition = 0;
                }
                result = result.Substring(0, lastWordPosition).Trim(new[] { '.', ',', '!', '?' }) + ellipsis;
            }
            return result;
        }
    }
