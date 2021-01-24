            List<Serials> serials = new List<Serials>
            {
                new Serials { Id = 1, Qty = 30, SRNo = "SR-001" },
                new Serials { Id = 2, Qty = 70, SRNo = "SR-002" }
            };
            decimal? QtyToBeIssued = 50;
            foreach (var item in serials)
            {
                if (QtyToBeIssued > item.Qty)
                {
                    QtyToBeIssued = QtyToBeIssued - item.Qty;
                    item.Qty = 0;
                }
                else
                {
                    item.Qty = item.Qty - QtyToBeIssued;
                }
            }
