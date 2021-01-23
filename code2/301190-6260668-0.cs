    class Comparer : IEqualityComparer <EntertainmentEvent>
    {
       public bool Equals( EntertainmentEvent x, EntertainmentEvent y )
       {
           return x.Startdate == y.Startdate;
       }
    
       public int GetHashCode( EntertainmentEvent event )
       {
          return event.StartDate.GetHasnCode();
       }
    
    }
    
    var duplicateDates = allEvents.Join
    (
        allEvents, x => x.StartDate, y => y.StartDate,
        (x, y) => x.Title != y.Title 
        ? new EntertainmentEvent
        {
            Title = string.Format("{0}, {1}", x.Title, y.Title),
            StartDate = x.StartDate
        }
        : null
    )
    .Where(x => x != null)
    .Distinct( new Comparer() )
    .ToList();
