    public class Pokémon
    {
        public string name { get; set; }
        public string url { get; set; }
    }
    
    public class ListOfPokémon
    {
        public List<Pokémon> results { get; set; }
    }
    var result = JsonConvert.DeserializeObject<ListOfPokémon>(jsonString);
    foreach (var p in result.results)
    {
        // ...
    }
