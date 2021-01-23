        private string ReplaceTemplateElements(Person person, string inputText)  
        {
            //RegExp to get everything like <Name>, <LastName>...
            Regex regExp = new Regex(@"\<(\w*?)\>", RegexOptions.Compiled);
            //Saves properties and values of the person object
            Dictionary<string, string> templateElements = new Dictionary<string, string>();
            FieldInfo[] fieldInfo;
            Type type = typeof(Person);
           
            fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            //Putting every property and value in the dictionary
            foreach (FieldInfo info in fieldInfo)
            {
                templateElements.Add(info.Name.TrimStart('_'), info.GetValue(person).ToString());
            }
            //Replacing the matching templateElements with the persons properties
            string result = regExp.Replace(inputText, delegate(Match match)
            {
                string key = match.Groups[1].Value;
                return templateElements[key];
            });
            return result;
        }
