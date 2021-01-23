    public IQueryable<Event> FindByLocation(float latitude, float longitude)
        {
            var eventsList = from ev in GetAllEvents()
                             join i in db.NearestEvents(latitude, longitude)
                             on ev.ID equals i.ID
                             select new Event { ID = ev.ID, Distance = i.Distance };
            return eventsList.OrderBy(e => e.Distance).AsQueryable();
        } 
