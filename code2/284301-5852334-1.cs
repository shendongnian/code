    EntityQuery<Web.Ticket> query =
               from t in _ticketContext.GetTicketsQuery().Include("Seats")
               where t.bookingId == data.bookingId
               select t;
        LoadOperation<Web.Ticket> loadOp = _ticketContext.Load(query);
        tk.ticketDataGrid.ItemsSource = loadOp.Entities;
