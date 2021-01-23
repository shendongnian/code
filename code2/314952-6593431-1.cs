    for (int i = 0; i < element.ChildNodes.Count; i++)
            {
                if (element.ChildNodes[i].Attributes["xmlns"] != null && element.ChildNodes[i].Attributes["xmlns"].Value == String.Empty)
                {
                    element.ChildNodes[i].Attributes.RemoveNamedItem("xmlns");
                }
                if (element.ChildNodes[i].HasChildNodes)
                {
                    element.ChildNodes[i].RemoveAll();
                }
            }
