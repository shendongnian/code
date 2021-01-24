    List<Serials> serials = new List<Serials>
            {
                new Serials { Id = 1, Qty = 30, SRNo = "SR-001" },
                new Serials { Id = 2, Qty = 70, SRNo = "SR-002" }
            };
            int QtyToBeIssued = 50;
            foreach (var item in serials)
            {
                int ToBeIssued = 0;
                if (QtyToBeIssued > 0)
                {
                    var temp = item.Qty - QtyToBeIssued < 0 ? 0 : item.Qty - QtyToBeIssued;
                    QtyToBeIssued -= item.Qty;
                    item.Qty = temp;
                }else
                {
                    break;
                }
            }
