    var count = 0;
    serials.ForEach(p =>
    {
        count++;
        if (QtyToBeIssued >= p.Qty)
        {
            QtyToBeIssued -= p.Qty;
            p.Qty = 0;
        }
        if (count == serials.Count)
        {
            p.Qty -= (int)QtyToBeIssued;
        }
    });
