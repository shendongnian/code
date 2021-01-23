            var person = new Person();
            person.FirstName = "Hello"; 
            person.LastName = "World";
            var dictionary = new Dictionary<string, string>();
            foreach(var propertyInfo in typeof(Person).GetProperties(BindingFlags.Public|BindingFlags.Instance))
            {
                var elementName = propertyInfo.Name.ToUpperInvariant();
                var value = (propertyInfo.GetValue(person, null) ?? string.Empty).ToString();
                dictionary.Add(elementName,value);
            }
            var xml = new XmlDocument();
            xml.LoadXml(File.ReadAllText(HttpContext.Current.Server.MapPath("~/template.htm")));
            foreach(var key in dictionary.Keys)
            {
                var matches = xml.GetElementsByTagName(key);
                for(int i = 0; i<matches.Count;i++)
                {
                    var match = matches[i];
                    var textNode = xml.CreateTextNode(dictionary[key]);
                    match.ParentNode.ReplaceChild(textNode, match);
                }
            }
