    var invoices = ( from c in _repository.Customers
                         where c.Id == id
                         from i in c.Invoices
                         select new InvoiceIndex
                         {
                             Id = i.Id,
                             CustomerName = i.Customer.Name,
                             Attention = i.Attention,
                             Total = i.Lines.Sum( l => l.CalcTotal ),
                             Posted = i.Created,
                             Salesman = i.Salesman.Name
                         }
        )
