    string StringFromRichTextBox(string XAML)
        {
            XElement root = XElement.Parse(XAML);
            XNamespace xmlns = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";
            StringBuilder sb = new StringBuilder();
            var Paras = root.Descendants(xmlns + "Paragraph");            
            foreach (XElement para in Paras)
            {
                foreach (XElement run in Paras.Descendants(xmlns + "Run"))
                {
                    XAttribute a = run.Attribute("Text");
                    sb.Append(null != a ? (string)a : "");
                }
            }
            return sb.ToString();
        }
