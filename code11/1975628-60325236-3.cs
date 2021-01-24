                var invlines = new List<Line>();
                foreach (var lineitem in inv.Lines)
                {
                    //Line
                    Line invoiceLine = new Line();
                    //Line Description
                    invoiceLine.Description = (((lineitem.PublicationName == "N/A" || lineitem.PublicationName == "-") ? "" : lineitem.PublicationName) + " " + lineitem.Description).Trim();
                    //Line Detail Type
                    invoiceLine.DetailType = LineDetailTypeEnum.SalesItemLineDetail;
                    invoiceLine.DetailTypeSpecified = true;
                    //Line Sales Item Line Detail
                    SalesItemLineDetail lineSalesItemLineDetail = new SalesItemLineDetail();
                    //Line Sales Item Line Detail - ItemRef
                    if (!string.IsNullOrEmpty(lineitem.ItemCode))
                    {
                        lineSalesItemLineDetail.ItemRef = new ReferenceType()
                        {
                            Value = lineitem.ItemCode
                        };
                    }
                    else if (item != null)
                    {
                        lineSalesItemLineDetail.ItemRef = new ReferenceType
                        {
                            name = item.Name,
                            Value = item.Id
                        };
                    }
                    //Line Sales Item Line Detail - UnitPrice
                    //Line Sales Item Line Detail - Qty
                    lineSalesItemLineDetail.Qty = 1;
                    lineSalesItemLineDetail.QtySpecified = true;
                    if (inv.DiscountPercent > 0)
                    {
                        invoiceLine.Amount = (decimal)lineitem.PriceBeforeDiscount;
                        invoiceLine.AmountSpecified = true;
                        lineSalesItemLineDetail.ItemElementName = ItemChoiceType.UnitPrice;
                    }
                    else
                    {
                        invoiceLine.Amount = (decimal)lineitem.Price;
                        invoiceLine.AmountSpecified = true;
                        lineSalesItemLineDetail.AnyIntuitObject = lineitem.Price;
                        lineSalesItemLineDetail.ItemElementName = ItemChoiceType.UnitPrice;
                    }
                    //Line Sales Item Line Detail - TaxCodeRef
                    //For US companies, this can be 'TAX' or 'NON'
                    var taxref = lineitem.TaxAmount == null || lineitem.TaxAmount == 0 ? nonvatid.ToString() : vatid.ToString();
                    if (country == "US")
                    {
                        taxref = lineitem.TaxAmount == null || lineitem.TaxAmount == 0 ? "NON" : "TAX";
                    }
                    lineSalesItemLineDetail.TaxCodeRef = new ReferenceType
                    {
                        Value = taxref
                    };
                    //Line Sales Item Line Detail - ServiceDate 
                    lineSalesItemLineDetail.ServiceDate = DateTimeService.Now.Date;
                    lineSalesItemLineDetail.ServiceDateSpecified = true;
                    //Assign Sales Item Line Detail to Line Item
                    invoiceLine.AnyIntuitObject = lineSalesItemLineDetail;
                    //Assign Line Item to Invoice
                    invlines.Add(invoiceLine);
                }
                if (inv.DiscountPercent > 0)
                {
                    Line invoiceLine = new Line();
                    DiscountLineDetail discLine = new DiscountLineDetail();
                    discLine.PercentBased = true;
                    discLine.DiscountPercent = (decimal)inv.DiscountPercent;
                    discLine.DiscountPercentSpecified = true;
                    discLine.PercentBased = true;
                    discLine.PercentBasedSpecified = true;
                    invoiceLine.DetailType = LineDetailTypeEnum.DiscountLineDetail;
                    invoiceLine.DetailTypeSpecified = true;
                    invoiceLine.AnyIntuitObject = discLine;
                    invlines.Add(invoiceLine);
                    invoice.DiscountRate = (decimal) (inv.DiscountPercent);
                    invoice.DiscountRateSpecified = true;
                }
                invoice.Line = invlines.ToArray();
