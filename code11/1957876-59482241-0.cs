class Program
{
    private static void Main(string[] args)
    {
        Assembly executingAssembly = Assembly.GetExecutingAssembly();
        Type countryType = executingAssembly.GetType("Refleksija.Country");
        var countryInstance =
            countryType.GetConstructor(new[] {typeof(string), typeof(int)})
                .Invoke(new object[] {"Srbija", 7_000_000});
        MethodInfo getCountryInfoMethod = countryType.GetMethod("GetCountryInfo");
        string CountryInfo = (string) getCountryInfoMethod.Invoke(countryInstance, new object[] { });
        Console.WriteLine("CountryInfo: = {0}", CountryInfo);
    }
}
class Country
{
    public string Name { get; set; }
    public int Population { get; set; }
    public Country(string name, int population)
    {
        Name = name;
        Population = population;
    }
    public string GetCountryInfo()
    {
        return "Country " + Name + " has the population of " + Population + ".";
    }
}
Also note that `GetCountryInfo` was being invoked with parameters, however it's a parameterless method.
