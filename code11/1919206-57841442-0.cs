    public IEnumerable<ExchangeRate> GetExchangeRates(IEnumerable<Currency> currencies)
    {
                var xmldoc = new XmlDocument();
                xmldoc.Load(@"http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
    
                XmlNodeList nodes = xmldoc.SelectNodes("//*[@currency]");
    
                if (nodes != null)
                {
                    foreach (XmlNode node in nodes)
                    {
                        var rate = new ExchangeRate()
                        {
                            SourceCurrency = new Currency("EUR"),
                            TargetCurrency = new Currency(node.Attributes["currency"].Value),
                            Value = (Decimal.Parse(node.Attributes["rate"].Value, NumberStyles.Any,
                                new CultureInfo("en-Us")))
                        };
                        // Change is here 
                        yield return rate;
                    }
                }
            }
    
        }
