    private string createXmlTags(TextBox textBox1, TextBox textBox2)
        {
            string strXml = string.Empty;
            string[] text1Val = textBox1.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] text2Val = textBox2.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            int count = 1;
            IList<XElement> testt = new List<XElement>();
            
            for (int i = 0; i < text1Val.Count(); i++)
            {
                testt.Add(new XElement("Entry" + count, text1Val[i]));
                while (!String.IsNullOrEmpty(text2Val[i]))
                {
                    count = count + 1;
                    testt.Add(new XElement("Entry"+count,text2Val[i]));
                    break;
                }
                count = count + 1;
            }
            foreach (var xElement in testt)
            {
                strXml += xElement.ToString();
            }
            return strXml;
        }
 
