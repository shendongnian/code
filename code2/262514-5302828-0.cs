    var doc = XDocument.Parse(xml);
    var data = from pin in doc.Descendants("Pin")
                select new
                {
                    Number = pin.Element("Number").Value,
                    Curves =
                        from curve in pin.Element("Curves").Descendants("Curve")
                        select new
                        {
                            Type = curve.Element("Type").Value,
                            VIPairs =
                                from pair in curve.Descendants("VIPair")
                                select new
                                {
                                    Voltage = pair.Element("Voltage").Value,
                                    Current = pair.Element("Current").Value
                                }
                        }
                };
