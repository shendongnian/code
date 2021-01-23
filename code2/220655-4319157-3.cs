        IEnumerable<TaxiCompany> CreateCompaniesFromXml(string xml)
        {
            XmlReader reader = XmlReader.Create(new StringReader(xml));
            TaxiCompany result = new TaxiCompany();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("pho:Title"))
                    {
                        result.Name = reader.ReadElementContentAsString();
                    }
                    if (reader.Name.Equals("pho:PhoneNumber"))
                    {
                        result.Phone = reader.ReadElementContentAsString();
                    }
                    if (result.Phone != null)
                    {
                        yield return result;
                        result = new TaxiCompany();
                    }
                }
            }
        }
