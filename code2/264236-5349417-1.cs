        public static XElement CleanupHtml(string input)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            HtmlDocument doc = new HtmlDocument();
            doc.OptionOutputAsXml = true;
            doc.LoadHtml(input);
            // extra processing, remove some attributes using DOM
            HtmlNodeCollection coll = doc.DocumentNode.SelectNodes("//br[@class='special_class']");
            if (coll != null)
            {
                foreach (HtmlNode node in coll)
                {
                    node.Attributes.Remove("class");
                }
            }
            using (StringWriter writer = new StringWriter())
            {
                doc.Save(writer);
                using (StringReader reader = new StringReader(writer.ToString()))
                {
                    return XElement.Load(reader);
                }
            }
        }
