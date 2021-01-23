    var ticketID = GetCurrentTicketId();
    IEnumerable<Ticket> res;
    using (var ct = new TrackerEntities)
    {
      res = from t in ct.Tickets
            where t.TicketID == ticketID
            select t;
    }
