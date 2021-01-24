    public static List<WorldEvent> Filter(string Country, List<WorldEvent> events) {
            var evs = from ev in events.Where(x => x.PresentationList.Any(y => y.Country == Country))
                      let targetPres = from pres in ev.PresentationList
                                       where pres.Country == Country
                                       select pres
                      select new WorldEvent {
                          ID = ev.ID,
                          Name = ev.Name,
                          PresentationList = targetPres.ToList()
                      };
            return evs.ToList();        
        }
