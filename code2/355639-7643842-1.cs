    var query = from shipment in context.ShippingHistory
                group shipment by shipment.MemberID into g
                select new { Count = g.Count(),
                         MemberID = g.Key,
                         MostRecentName = g.OrderByDescending(x => x.ShipmentDate)
                                           .First()
                                           .ShipmentName };
