     public void ConfirmRide(Ride dbRide, int id, string status)
        {
            dbRide.MapStatus(status);
            Update(dbRide);
            var existingParent = RepositoryContext.Rides
                                 .Where(p => p.Id == id)
                                 .Include(p => p.Requests).Where(r => r.Requests.Any( request => request.Status == "Approved"))
                                 .SingleOrDefault();
            if (existingParent != null)
            {
  
                foreach (var existingChild in existingParent.Requests.ToList())
                {
                    existingChild.Status = "Confirmed";
                }
            }
            RepositoryContext.SaveChanges();
        }
