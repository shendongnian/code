    var summary = db.BillHistories.FirstOrDefault(a => a.CustomerId == customerNumber && a.DueDate == dt && a.Type == "BILL").Select(x => new BillSummary
                                   {
                                       Id = a.Id,
                                       CustomerId = a.CustomerId,
                                       DueDate = a.DueDate,
                                       PreviousBalance = a.PreviousBalance.Value,
                                       TotalBill = a.TotalBill.Value,
                                       Type = a.Type,
                                       IsFinalBill = a.IsFinalBill
                                   });
