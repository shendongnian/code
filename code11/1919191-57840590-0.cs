    var openInvoiceData = _Context.Invoice
              .Where(i =>
              i.InvoiceDate.Date == model.CurrentDate.Date)
              .Select(i => new Contracts.OpenInvoiceData()
              {
                  CustomerId = i.BillToId != null && i.BillTo.CustomerBillTo.Include(d=>d.Customer).Where(x => x.CustomerType == Enum.EnumCustomerType.BillTo).FirstOrDefault() != null
           ? i.BillTo.CustomerBillTo.Include(d=>d.Customer).Where(x => x.CustomerType == Enum.EnumCustomerType.BillTo).FirstOrDefault().Customer.CustomerId 
           : i.Customer.CustomerId
              }).ToList();
