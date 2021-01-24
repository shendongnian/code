    public static class XmlHelpers
    {
        public static T DeserializeXmlObject<T>(string xml) where T : class
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default;
            }
            
            using (var stringReader = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                
                return (T) serializer.Deserialize(stringReader);
            }
        }
        
        public static List<T> PopulateDtoFromXml<T>(string pathToXsl, string inputXml) where T : class
        {
            var stylesheet = new XslCompiledTransform();
            stylesheet.Load(pathToXsl);
            
            
            List<T> returnList = default;
            
            using (var sr = new StringReader(inputXml))
            {
                using (var xr = XmlReader.Create(sr))
                {
                    using (var sw = new StringWriter())
                    {
                        stylesheet.Transform(xr, null, sw);
                        var resultXml = sw.ToString();
                        
                        var cleanXml = XDocument.Parse(resultXml, LoadOptions.None);
                        cleanXml.Descendants()
                            .Where(e => e.IsEmpty || string.IsNullOrWhiteSpace(e.Value))
                            .Remove();
                        var listOfItems = cleanXml.Descendants().Where(x => x.HasElements && x.Ancestors().Any()).ToList();
                        foreach (var item in listOfItems)
                        {
                            try
                            {
                                var result = DeserializeXmlObject<T>(item.ToString());
                                if (result == null) continue;
                                if (returnList == null) returnList = new List<T>();
                                returnList.Add(result);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                        }
                        
                    
                    }
                }
            }
            
            return returnList;
        }
    }
