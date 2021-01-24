    list2.AddRange(
        list1.Select(
            a => {
                b = new BidCostModelFormatted();
                b.Code = a.Code;
                b.Month1 = a.Month1.ToString("N");
                b.Month2 = a.Month2.ToString("N");
                b.Month3 = a.Month3.ToString("N");
                return b;
            }
        )
    );
