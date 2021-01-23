    /// <summary>
    /// Extends the LinqToTwitter Library
    /// </summary>
    public static class TwitterExtensions
    {
        private static readonly Regex _parseUrls = new Regex("\\b(([\\w-]+://?|www[.])[^\\s()<>]+(?:\\([\\w\\d]+\\)|([^\\p{P}\\s]|/)))", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex _parseMentions = new Regex("(^|\\W)@([A-Za-z0-9_]+)", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static readonly Regex _parseHashtags = new Regex("[#]+[A-Za-z0-9-_]+", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    
        /// <summary>
        /// Parse Status Text to HTML equivalent
        /// </summary>
        /// <param name="status">The LinqToTwitter <see cref="Status"/></param>
        /// <returns>Formatted HTML string</returns>
        public static string TextAsHtml(this Status status)
        {
            string tweetText = status.Text;
    
            if (!String.IsNullOrEmpty(tweetText))
            {
                // Replace URLs
                foreach (var urlMatch in _parseUrls.Matches(tweetText))
                {
                    Match match = (Match)urlMatch;
                    tweetText = tweetText.Replace(match.Value, String.Format("<a href=\"{0}\" target=\"_blank\">{0}</a>", match.Value));
                }
    
                // Replace Mentions
                foreach (var mentionMatch in _parseMentions.Matches(tweetText))
                {
                    Match match = (Match)mentionMatch;
                    if (match.Groups.Count == 3)
                    {
                        string value = match.Groups[2].Value;
                        string text = "@" + value;
                        tweetText = tweetText.Replace(text, String.Format("<a href=\"http://twitter.com/{0}\" target=\"_blank\">{1}</a>", value, text));
                    }
                }
    
                // Replace Hash Tags
                foreach (var hashMatch in _parseHashtags.Matches(tweetText))
                {
                    Match match = (Match)hashMatch;
                    string query = Uri.EscapeDataString(match.Value);
                    tweetText = tweetText.Replace(match.Value, String.Format("<a href=\"http://search.twitter.com/search?q={0}\" target=\"_blank\">{1}</a>", query, match.Value));
                }
            }
    
            return tweetText;
        }
    }
