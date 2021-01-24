               foreach (XElement sellResponse in rootElement.Elements())
                {
                    if (sellResponse.Name == "Header")
                    {
                        itemCustom.ErrorCode = sellResponse.Element("ErrorCode").Value;
                        itemCustom.ErrorMessage = sellResponse.Element("ErrorMessage").Value;
                    }
                    else if (sellResponse.Name == "Customer")
                    {
                        itemCustom.CustomerID = sellResponse.Element("CustomerID").Value;
                        itemCustom.CustomerType = sellResponse.Element("CustomerType").Value;
                    }
                }
