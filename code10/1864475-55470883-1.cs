    var projectNum = clientsCollection
      .Where(p => p.ID == edit.Clients_ID)
      .Select(p => (int?)p.ProjectNo)
      .FirstOrDefault();
      
    if (projectNum != null)
    {
        // you find that number
    }
    else
    {
        // there is no item with such edit.Clients_ID
    }
