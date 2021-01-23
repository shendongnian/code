    try {
      _context.AddObject(TableName, entityObject);
      _context.SaveCangesWithRetries(); 
    }
    catch(DataServiceRequestException ex) {
      ex.Response.Any(r => r.StatusCode == (int)System.Net.HttpStatusCode.Conflict) 
      throw;
    }
