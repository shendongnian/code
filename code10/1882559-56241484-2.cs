    using (var transaction = _context.Database.BeginTransaction())
    {
        try
        {
	
	        bool tracking = _context.ChangeTracker.Entries<Anomaly>().Any(x => x.Entity.Id == anomaly.Id);
		    if (!tracking)
		    {
			    _context.Anomalies.Update(anomaly);
		    }
		
            _context.SaveChanges();
 
            transaction.Commit();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            throw;
        }
    }
