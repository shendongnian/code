    string date = baseXML.Descendants(bat + "Batch")
                         .Elements(bat + "PurchaseOrder")
                         .Elements(bat + "OrderHeader")
                         .Elements(bat + "POIssuedDate")
                         .First().Value
