    var result = worldEventList.Select(x => new WorldEvent()
                     {
                         ID = x.ID,
                         Name = x.Name,
                         PresentationList = x.PresentationList.Where(y => y.Country == country).ToList()
                     }).Where(x => x.PresentationList.Any())
                       .ToList();
