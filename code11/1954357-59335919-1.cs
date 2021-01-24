        public List<string> GetValueByXmlParse(string input)
        {
            var result = new List<string>();
            var ensureThereAreOnlyOneRootTag = $"<root>{input}</root>";
            XDocument xmlDocument = XDocument.Parse(ensureThereAreOnlyOneRootTag);
            foreach(var personXml in xmlDocument.Root.Elements("Person"))
            {
                result.Add(String.Concat(personXml.Nodes()));
            }
            return result;
        }
