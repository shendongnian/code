    var client = _context.Client
                             .Include(x => x.State)
                             .Where(w => w.client_id == clientId
                             .FirstOrDefault(); 
  
     //or just get the state .. var state = _context.State..
    clientModel.State = client.State;
    return View(clientModel);
