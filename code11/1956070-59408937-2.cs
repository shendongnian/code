    var list = db.Notes
         .Join(
             tickets,
             note => note.TicketID,
             tick => tick.ID,
             (note, tick) => new { note, tick}
             
         )
         .ToList();
         foreach(var item in list)
              item.note.Ticket = item.tick;
