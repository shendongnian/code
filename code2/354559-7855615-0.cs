    foreach (XPathNavigator NewLines in MaterialLines)
                    {
                        lineCount += 1;
                        if (NewLines.SelectSingleNode(".//my:ForQuote", NamespaceManager).Value == "false" && NewLines.SelectSingleNode(".//my:LineSubmitted", NamespaceManager).Value == "false")
                        {
                            using (SPSite site = SPContext.Current.Site)
                            {
                                if (site != null)
                                {
                                    using (SPWeb web = site.OpenWeb())
                                    {
                                        // Turn on AllowUnsafeUpdates on the site
                                        web.AllowUnsafeUpdates = true;
                                        // Update the SharePoint list based on the values
                                        // from the InfoPath form
                                        SPList list = web.GetList("/Lists/InfoPathRtpItems");
                                        if (list != null)
                                        {
                                            SPListItem item = list.Items.Add();
                                            item["Title"] = NewLines.SelectSingleNode(".//my:lineItem", NamespaceManager).Value;
                                            item["RMANumber"] = MainDataSource.CreateNavigator().SelectSingleNode("./my:myFields/my:EntitlementContainer/my:RMANumber", NamespaceManager).Value;
                                            item["UnitSerialNumber"] = MainDataSource.CreateNavigator().SelectSingleNode("./my:myFields/my:EntitlementContainer/my:serialNumber", NamespaceManager).Value;
                                            item["ShipDate"] = MainDataSource.CreateNavigator().SelectSingleNode("./my:myFields/my:ShippingInformation/my:ShipDate", NamespaceManager).Value;
                                            item["OrderType"] = MainDataSource.CreateNavigator().SelectSingleNode("./my:myFields/my:RepairQuote/my:orderType", NamespaceManager).Value;
                                            item["QuoteNumber"] = MainDataSource.CreateNavigator().SelectSingleNode("./my:myFields/my:RepairQuote/my:quoteNumber", NamespaceManager).Value;
                                            item["LineQuantity"] = NewLines.SelectSingleNode(".//my:lineQuantity", NamespaceManager).Value;
                                            item["LineNumber"] = lineCount.ToString();
                                            item.Update();
                                        }
                                        // Turn off AllowUnsafeUpdates on the site
                                        web.AllowUnsafeUpdates = false;
                                        // Close the connection to the site
                                        web.Close();
                                    }
                                    // Close the connection to the site collection
                                    site.Close();
                                }
                            }
                        }
