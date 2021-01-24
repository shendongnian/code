    _db.Jobs.IsDelivered().HasPayments()
       .Select(x => new 
       {
          x.JobId,
          Payments = x.Payments.Sum(c => c.Amount ?? 0),
          Price = x.Price ?? 0,
          x.Discount,
          JobExtraSum = x.JobExtras.Sum(c => c.Price ?? 0),
          TipsSum = x.Tips.Sum(c => c.Amount ?? 0)
       }).ToList();
