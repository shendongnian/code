        private void traverse(ref XmlNode node)
        {
            XmlNode prevOldElement = null;
            XmlNode prevNewElement = null;
            var element = node.FirstChild;
            do
            {
                if (prevNewElement != null && prevOldElement != null)
                {
                    prevOldElement.ParentNode.ReplaceChild(prevNewElement, prevOldElement);
                    prevNewElement = null;
                    prevOldElement = null;
                }
                if (element.NodeType == XmlNodeType.Text)
                {
                    var el = doc.CreateElement("text");
                    //Here is manuplation of the InnerXml.
                    el.InnerXml = element.Value.Replace(a_search_term, "<b>" + a_search_term + "</b>");
                    //I don't replace element right now, because element.NextSibling will be null.
                    //So I replace the new element after getting the next sibling.
                    prevNewElement = el;
                    prevOldElement = element;
                }
                else if (element.HasChildNodes)
                    traverse(ref element);
            }
            while ((element = element.NextSibling) != null);
            if (prevNewElement != null && prevOldElement != null)
            {
                prevOldElement.ParentNode.ReplaceChild(prevNewElement, prevOldElement);
            }
        }
