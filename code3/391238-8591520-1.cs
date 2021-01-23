    string date = baseXML.Descendants(bat + "Batch")
                         .Elements(ns + "PurchaseOrder")
                         .Elements(ns + "OrderHeader")
                         .Elements(ns + "POIssuedDate")
                         .First().Value
