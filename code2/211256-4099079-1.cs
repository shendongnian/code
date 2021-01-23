        public XDocument FormatcountPreProcData(XDocument inputDoc)
        {
            if (inputDoc != null)
            {
                var elementsToChange = inputDoc.Elements("NEWFILE").Elements("NEWRECORD").Elements();
                foreach (var element in elementsToChange)
                {
                    if (element.Descendants().Any())
                    {
                        Int32 count = inputDoc.Elements("NEWFILE").Elements("NEWRECORD").Elements(element.Name.ToString()).Count();
                        element.Add(new XAttribute("count", count));
                    }
                }
            }
            return inputDoc;
        }
