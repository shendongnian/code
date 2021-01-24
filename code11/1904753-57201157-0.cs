csharp
public class Country
{
  public string Code { get; set; }
  public string Name { get; set; }
  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  public IList<Region> Regions { get; set; }
  public Country() { }
  public Country(Database.Models.Country country)
  {
    this.Code = country.Code;
    this.Name = country.Name;
    if (country.CountryRegions != null)
    {
      this.Regions = country.CountryRegions
        .Select(cr => { cr.Region.CountryRegions = null; return new Region(cr.Region); })
        .ToList();
    }
  }
  public static explicit operator Country(Database.Models.Country country)
  {
    return country != null ? new Country(country) : null;
  }
}
csharp
public class Region
{
  public string Code { get; set; }
  public string Name { get; set; }
  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
  public IList<Country> Countries { get; set; }
  public Region() { }
  public Region(Database.Models.Region region)
  {
    this.Code = region.Code;
    this.Name = region.Name;
    if (region.CountryRegions != null)
    {
      this.Countries = region.CountryRegions
        .Select(cr => { cr.Country.CountryRegions = null; return new Country(cr.Country); })
        .ToList();
    }
  }
  public static explicit operator Region(Database.Models.Region region)
  {
    return region != null ? new Region(region) : null;
  }
}
