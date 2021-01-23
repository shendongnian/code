    class SourceType
    {
        public int Id;
        public string Name;
        public int Age { get; set; }
        // other properties
    }
    
    class DestinationType
    {
        public int Id;
        public string Name;
        public int Age { get; set; }
        // other properties
    }
        List<SourceType> sourceList = new List<SourceType>();
        sourceList.Add(new SourceType { Id = 1, Name = "1111", Age = 35});
        sourceList.Add(new SourceType { Id = 2, Name = "2222", Age = 26});
        sourceList.Add(new SourceType { Id = 3, Name = "3333", Age = 43});
        sourceList.Add(new SourceType { Id = 5, Name = "5555", Age = 37});
        List<DestinationType> destinationList = new List<DestinationType>();
        destinationList.Add(new DestinationType { Id = 1, Name = null });
        destinationList.Add(new DestinationType { Id = 2, Name = null });
        destinationList.Add(new DestinationType { Id = 3, Name = null });
        destinationList.Add(new DestinationType { Id = 4, Name = null });
        var mapped= destinationList.Join(sourceList, d => d.Id, s => s.Id, (d, s) =>
        {
            d.Name = s.Name;
            d.Age = s.Age;
            return d;
        }).ToList();
