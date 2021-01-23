    public IEnumerable<Animals> AllSpotted()
    {
        return from a in Zoo.Animals
               where a.coat.HasSpots == true
               select a;
    }
    public IEnumerable<Animals> Feline(IEnumerable<Animals> sample)
    {
        return from a in sample
               where a.race.Family == "Felidae"
               select a;
    }
    public IEnumerable<Animals> Canine(IEnumerable<Animals> sample)
    {
        return from a in sample
               where a.race.Family == "Canidae"
               select a;
    }
