        private static void Serialize_PossibleHTMLElementToString(object sender, XmlElementEventArgs e)
        {
            if (e.ObjectBeingDeserialized != null)
            {
                var node = e.Element.InnerXml;
                string elementName = e.Element.Name;
                Item item = (Item)e.ObjectBeingDeserialized;
                var element = item.GetType().GetProperties().FirstOrDefault(x => x.GetCustomAttributes(typeof(XmlElementAttribute), true).Where(attr => (attr as XmlElementAttribute).ElementName == elementName).Count() > 0);
                if(element != null)
                    element.SetValue(item, node.Trim());
            }
        }
