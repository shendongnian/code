    public IActionResult Index()
            {
                #region ListeDesPokemons
                var pokemonList = new List<PokemonModel>();
                var Id = 1;
                var Img = 1;
                pokemonList.Add(new PokemonModel() { Id = Id++, Name = "Bulbizarre", UsName = "Bulbasaur(us)", JpName = "フシギダネ(jp)", Type1 = "Plante", Type2 = "Poison", Rate = 45, Image = "https://eternia.fr/public/media/pokedex/artworks/00" + Img++ + ".png" });
                pokemonList.Add(new PokemonModel() { Id = Id++, Name = "Herbizarre", UsName = "Ivysaur(us)", JpName = "フシギソウ(jp)", Type1 = "Plante", Type2 = "Poison", Rate = 45, Image = "https://eternia.fr/public/media/pokedex/artworks/00" + Img++ + ".png" });
                 var model = new PokemonViewModel();
                model.Pokemons = pokemonList;
                var json = JsonConvert.SerializeObject(pokemonList);
                TempData["pokemonListJson"] = json;
                TempData.Keep("PokemonListJson");
                ViewBag.TotalPokemon1G = pokemonList.Count;
                return View(model);
            }
            
            
             [HttpPost]
            public IActionResult PokemonDetails(int pokemonId)
            {
                if (TempData["pokemonListJson"] != null)
                {
                    if (string.IsNullOrEmpty(TempData["pokemonListJson"].ToString()))
                    {
                        return null;
                    }
                }
                var pokemonListJson = TempData["pokemonListJson"].ToString();
                TempData.Keep("PokemonListJson");
                var pokemonList = JsonConvert.DeserializeObject<List<PokemonModel>>(pokemonListJson);
                var selectedPokemon = pokemonList.SingleOrDefault(p => p.Id == pokemonId);
                if (selectedPokemon != null)
                {
                    return PartialView("_PokemonDetails", selectedPokemon);
                }
                return null;
            }
