    public IQueryable<Event> FindByLocation(float latitude, float longitude)
        {
            var eventsList = from ev in GetAllEvents()
                             join i in db.NearestEvents(latitude, longitude)
                             on ev.ID equals i.ID
                             select new { TheEvent = ev, Distance = i.Distance };
            foreach (var item in eventsList)
            {
                item.TheEvent.Distance = item.Distance;  
            }
            return eventsList.OrderBy(e => e.Distance).Select(e => e.TheEvent);
        } 
