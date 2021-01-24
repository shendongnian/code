    var allHouses = new[]
    {
        new House { Uid = 1, Name = "House 1" },
        new House { Uid = 2, Name = "House 2" },
        new House { Uid = 3, Name = "House 3" },
    };
    var assignedHouses = new[] { allHouses[0] };
    var availableHouses = allHouses.Where(house => assignedHouses.All(assigned => 
        assigned.Uid != house.Uid)).ToList();
    Console.WriteLine($"Available houses: {string.Join(",", availableHouses.Select(i => i.Name))}");
    Console.Read();
