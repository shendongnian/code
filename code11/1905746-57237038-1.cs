        var doc = XDocument.Parse(file);
        XNamespace ns0 = doc.Root.GetNamespaceOfPrefix("ns0");
        XElement recipientDeliveries = doc.Descendants(ns0 + "RecipientDeliveries").FirstOrDefault();
        var recipients = recipientDeliveries.Descendants(ns0 + "Recipient").ToList();
        var RecipientList = new List<Recipient>();
        foreach (var item in recipients)
        {
            var deliveries = item.Descendants(ns0 + "Deliveries").FirstOrDefault();
            var deliveriesNodes = deliveries.Descendants(ns0 + "Delivery").ToList();
            var recipientInfo = item.Descendants(ns0 + "RecipientNameAndAddress").FirstOrDefault();
            var recipientAddress = recipientInfo.Descendants(ns0 + "Address").FirstOrDefault();
            var deliverList = new List<RecipientDelivery>();
            foreach (var del in deliveriesNodes)
            {
                var delivery = new RecipientDelivery()
                {
                    DeliveryID = del.Element(ns0 + "DeliveryID").Value,
                    DeliveryType = del.Element(ns0 + "DeliveryType").Value,
                    DeliveryRoute = del.Element(ns0 + "DeliveryRoute").Value,
                    ToteID = del.Element(ns0 + "ToteID").Value,
                    NursingStation = del.Element(ns0 + "NursingStation").Value
                };
                deliverList.Add(delivery);
            }
            var recipient = new Recipient()
            {
                RecipientCode = Convert.ToInt32(item.Element(ns0 + "RecipientCode").Value),
                RecipientNameAndAddress = new RecipientInfo()
                {
                    Name = recipientInfo.Element(ns0 + "Name").Value.ToString(),
                    Address = new RecipientAddress()
                    {
                        Line1 = recipientAddress.Element(ns0 + "Line1").Value.ToString(),
                        CityTownOrLocality = recipientAddress.Element(ns0 + "CityTownOrLocality").Value.ToString(),
                        StateOrProvince = recipientAddress.Element(ns0 + "StateOrProvince").Value.ToString(),
                        PostalCode = recipientAddress.Element(ns0 + "PostalCode").Value.ToString()
                    },
                }, 
                Deliveries = deliverList
            };
            RecipientList.Add(recipient);
        }
