     public static string TextAbstract(string text, int length)
            {
                if (text == null)
                {
                    return string.Empty;
                }
                if (text.Length <= length)
                {
                    return text;
                }
                text = text.Substring(0, length);
                text = text.Substring(0, text.LastIndexOf(" "));
                return text + "...";
            }
