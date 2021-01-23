    public List<BillType> GetAllBills()
    {
        using (BillsEntities be = new BillsEntities())
        {
            var results = from o in be.Bills
                         .Include("Type")
                         .Include("Repeat")
                          select new BillType
                          {
                              BillId = o.BillId,
                              Name = o.Name,
                              URL = o.URL,
                              PaymentAmount = o.PaymentAmount,
                              Balance = o.Balance,
                              DueDate = o.DueDate,
                              TypeDesc = o.Type.TypeDesc,
                              RepeatDesc = o.Repeat.RepeatDesc,
                              Username = o.UserName 
                          };
           return results.ToList();
        }
    }
