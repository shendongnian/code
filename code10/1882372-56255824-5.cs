    var anomly = _context.Anomalies
     .Include(a => a.Asset)
     .FirstOrDefaultAsync(a => a.Id == anomalyId);
    
    anomly.Description = "I have changed the description";
    
    _context.Dispose();
    
    _context = new DBContext();
    
    var databaseAnomoly = _context.Anomalies
     .Include(a => a.Asset)
     .FirstOrDefaultAsync(a => a.Id == anomaly.Id);
    
    //Update fields
    databaseAnomoly.Description = anomly.Description;
    _context.SaveChanges();
