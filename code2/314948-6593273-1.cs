    private XElement RemoveEmptyNamespace(XElement element) {
            foreach (XElement el in element.Elements()) {
                if (el.Attribute("xmlns") != null && el.Attribute("xmlns").Value == string.Empty)
                    el.Attribute("xmlns").Remove();
                if (el.HasElements)
                    el = RemoveEmptyNamespace(el);
            }
          return element;
        }
