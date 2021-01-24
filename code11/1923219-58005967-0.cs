    public class PokemonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UsName { get; set; }
        public string JpName { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int Rate { get; set; }
        public string Image { get; set; }
    }
    public class PokemonViewModel
    {
        public List<PokemonModel> Pokemons { get; set; }
    }
