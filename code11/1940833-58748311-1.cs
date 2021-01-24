            using (StreamReader r = new StreamReader(xmlfilepath))
            {
                string xmlString = r.ReadToEnd();
                XmlSerializer ser = new XmlSerializer(typeof(MarketingAllCardholder));
                using (TextReader reader = new StringReader(xmlString))
                {
                    var marketingAllCardholder = (MarketingAllCardholder)ser.Deserialize(reader);
                    var engine = new FileHelperEngine<MarketingAllCardholderData>();
                    engine.HeaderText = engine.GetFileHeader();
                    string filePath = Path.Combine(@"C:\RnD", "testfile" + ".csv");
                    engine.WriteFile(filePath , (IEnumerable<MarketingAllCardholderData>)marketingAllCardholder.MarketingAllCardholderData);
                }
            }
