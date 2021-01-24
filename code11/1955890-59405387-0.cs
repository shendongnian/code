                var xDoc = new XmlDocument();
            xDoc.LoadXml(responseXml);
            itemSell.ErrorCode = xDoc.SelectNodes("//ErrorCode")[0].InnerText;
            itemSell.ErrorMessage = xDoc.SelectNodes("//ErrorMessage")[0].InnerText;
            itemSell.CustomerID= xDoc.SelectNodes("//CustomerID")[0].InnerText;
