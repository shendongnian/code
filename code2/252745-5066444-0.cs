        public XElement filter(int min = 0, int max = int.MaxValue)
        {            
            XElement filtered = new XElement("Stock");
            foreach (XElement product in xmlFile.Elements("Product"))
            {
                if ((int)product.Element("Price") >= min &&
                    (int)product.Element("Price") <= max)
                        filtered.Add(product);
            }
            return filtered;
        }
