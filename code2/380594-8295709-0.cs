    public static string ClearHTMLTagsFromString(string htmlString)
            {
                string regEx = @"\<[^\<\>]*\>";
                string tagless = Regex.Replace(htmlString, regEx, string.Empty);
                // remove rogue leftovers     
                tagless = tagless.Replace("<", string.Empty).Replace(">", string.Empty);
                tagless = tagless.Replace("Body:", string.Empty);
                return tagless;
            } 
