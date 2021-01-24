     var supplier = _context.Suppliers
                            .Include(x => SalesOrders)
                            .Single(s => s.Id == id);
     SalesOrderViewModel viewModel = new SalesOrderViewModel
     {
          Supplier = supplier,
          SalesOrder = supplier.SalesOrder
     };
