    public class Country
    {
        public string Code { get; }
        public string Name { get; }
        public Country(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
    private IEnumerable<Country> GetCountries()
    {
        yield return new Country("code", "Earth");
        yield return new Country("code", "Vulkan");
    }
