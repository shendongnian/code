    var query = from assign in OrderAssignTable
                join master in OrderMasterTable on assign.Order_ID equals master.Order_ID
                where master.IsDelivered == true
                group new { assign, master } by assign.Delivery_Date.Date into g
                select new
                {
                    Date = g.Key,
                    OnTime = g.Count(i => i.assign.Delivery_Date <= i.master.ExpectedDelivery_Date),
                    Delayed = g.Count(i => i.assign.Delivery_Date > i.master.ExpectedDelivery_Date)
                };
