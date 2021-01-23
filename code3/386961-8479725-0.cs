            foreach (BillPaymentSummary payment in billPayments)
            {
                var data = db.BillHistories.Where(b => b.CustomerId == customerNumber && b.DueDate == payment.DueDate && b.Type == "B").FirstOrDefault();
                if (data != null) // There is a bill history
                {
                    returnSummaries.Add(new BillSummary
                    {
                        Id = data.Id,
                        CustomerId = data.CustomerId,
                        DueDate = data.DueDate,
                        PreviousBalance = data.PreviousBalance,
                        TotalBill = data.TotalBill,
                        Type = (data.Type.Trim() == "B" ? "BILL" : (data.Type == "A" ? "ADJ" : "")),
                        IsFinalBill = data.IsFinalBill,
                        PayDate = payment.PaidDate,
                        AmountPaid = payment.AmountPaid
                    });
                }
                else // No bill history record, look for an adjustment
                {
                    data = db.BillHistories.FirstOrDefault(b => b.CustomerId == customerNumber && b.DueDate == payment.DueDate && b.Type == "A");
                    if (data != null)
                    {
                        returnSummaries.Add(new BillSummary
                        {
                            Id = data.Id,
                            CustomerId = data.CustomerId,
                            DueDate = data.DueDate,
                            PreviousBalance = data.PreviousBalance,
                            TotalBill = data.TotalBill,
                            Type = (data.Type.Trim() == "B" ? "BILL" : (data.Type == "A" ? "ADJ" : "")),
                            IsFinalBill = data.IsFinalBill,
                            PayDate = payment.PaidDate,
                            AmountPaid = payment.AmountPaid
                        });
                    }
                }
                db.SaveChanges();
            }
