        public static string HighlightKeyWords(string s, string[] KeyWords)
        {
            if (KeyWords != null && KeyWords.Count() > 0 && !string.IsNullOrEmpty(s))
            {
                foreach (string word in KeyWords)
                {
                    s = System.Text.RegularExpressions.Regex.Replace(s, word, string.Format("{0}", "{0}$0{1}"), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                }
            }
            s = string.Format(s, "<mark class='hightlight_text_colour'>", "</mark>");
            return s;
        }
