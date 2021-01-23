         public static void ProcessDayAheadQuery(string requestXml, int syncEntityId, string muiUrl)
        {
            var repsonseXML = XDocument.Load(XmlReader.Create(CallMUIStream(requestXml, muiUrl)));
            XNamespace ns = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace ns2 = "http://markets.midwestiso.org/dart/xml";
            using (var db = new IntLMPDB())
            {
                SyncJob syncEntity =
                    (from s in db.SyncJob where s.SyncId == syncEntityId select s).FirstOrDefault();
                DateTime rDay = DateTime.Now;
                String query = String.Empty;
                foreach (XElement xe in repsonseXML.Descendants(ns + "Envelope").FirstOrDefault().Descendants(ns2 + "QueryResponse").Descendants(ns2 + "DayAheadLMP"))
                {
                    rDay = DateTime.Parse(xe.FirstAttribute.Value);
                    query = xe.Name.LocalName;
                    // string day = xe.FirstAttribute.Value;
                    foreach (XElement node in xe.Descendants(ns2 + "PricingNode"))
                    {
                       // string location = node.FirstAttribute.Value;
                        strin
                        foreach (XElement hourly in node.Descendants(ns2 + "PricingNodeHourly"))
                        {
                            //var newRow = new LMP_DayAhead
                            //{
                            //    Location = node.FirstAttribute.Value,
                            //    Interval = rDay.AddHours(Double.Parse(hourly.FirstAttribute.Value)),
                            //    LMP = decimal.Parse(hourly.Descendants(ns2 + "LMP").FirstOrDefault().Value),
                            //    MLC = decimal.Parse(hourly.Descendants(ns2 + "MLC").FirstOrDefault().Value),
                            //    MCC = decimal.Parse(hourly.Descendants(ns2 + "MCC").FirstOrDefault().Value),
                            //    SyncJob = syncEntity
                            //};
                            //db.AddToLMP_DayAhead(newRow);     
                        }
                    }
                }
                db.SaveChanges();
                UpdateLastDbPost(db, query, rDay);
            } 
        }
