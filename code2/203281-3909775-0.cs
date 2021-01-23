    private string ParseTagsFromPage(string pageContent)
        {
            string regexPattern = "{zeus:(.*?)}"; //matches {zeus:anytagname}
            string tagName = "";
            string fieldName = "";
            string replacement = "";
            MatchCollection tagMatches = Regex.Matches(pageContent, regexPattern);
            foreach (Match match in tagMatches)
            {
                tagName = match.ToString();
                fieldName = tagName.Replace("{zeus:", "").Replace("}", "");
                //get data based on my found field name, using some other function call
                replacement = GetFieldValue(fieldName); 
                pageContent = pageContent.Replace(tagName, replacement);
            }
            return pageContent;
        }
