    public class LinqOrderingForWords
    {
        IList<string> _places;
        public LinqOrderingForWords()
        {
            _places = new List<string> { "MOUNT ADA", "MOUNTAIN BAY", "MOUNT BEAUTY", "MOUNTAIN VIEW", "MOUNTAIN GATE", "MOUNT ALFRED", "MOUNT ADA ONE" };
        }
        public void OrderPlaces()
        {
            var sorted = _places.OrderBy(s => s);
            sorted.ToList().ForEach(s => Console.WriteLine(s));
        }
    }
