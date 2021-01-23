    var journeys = new List<Journey>();
    journeys.Add(new Journey() { Name = "Test1", Status = Journey.JourneyStatus.Enroute });
    journeys.Add(new Journey() { Name = "Test2", Status = Journey.JourneyStatus.Error });
    journeys.Add(new Journey() { Name = "Test3", Status = Journey.JourneyStatus.Finished });
    journeys.Add(new Journey() { Name = "Test4", Status = Journey.JourneyStatus.Enroute });
    
    journeys = journeys.OrderBy(x => x.Status).ToList();
    
    foreach (var j in journeys)
        Console.WriteLine("{0} : {1}", j.Name, j.Status);
