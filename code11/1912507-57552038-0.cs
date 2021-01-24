    var worldEvent = new WorldEventService.GetWorldEvents();
    var filter = "";//userInput
    var filteredResult = worldEvent.Select(r => new WorldEvent
                         { 
                             PresentationList = r.PresentationList.Where(c => c.Country == filter).ToList(),
                             ID = r.Id,
                             Name = r.Name 
                         }).ToList();
