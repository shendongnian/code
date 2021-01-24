public class Country
{
  public int CountryId{get;set;}
  pulic string Name{get;set;}
  public string Culture{get;set;}
}
public class City
{
   public int CityId{get;set;}
   public string Name{get;set;}
   public Country Country{get;set;}
}
We are going to select a city with id 1:
using(var dbContext = new SampleDbContext())
{
  var city = dbContext.Cities.SingleOrDefault(c => c.CityId == 1);
  var country = city.Country;
  // country will be null
  // because EF didn't fetch its data, because it's an eager-load
}
The query above generate query like:
       SELECT * FROM Cities WHERE CityId = 1
And as I mentioned in the code comments above, `City.Country` will be null due to using `eager-loading`. In this case to load navigation properties you can use `Include` method.
using(var dbContext = new SampleDbContext())
{
  var city = dbContext.Cities
                      .Include(c => c.Country)
                      .SingleOrDefault(c => c.CityId == 1);
}
The query will generate SQL:
SELECT * FROM Cities ci
INNER JOIN Countries c ON ci.CountryId = c.CountryId
Addition to the eager-loading, don't forget that you can always use projection in your queries. For example, in our sample we need to fetch only CityName and CountryName:
using(var dbContext = new SampleDbContext())
{
  var cities=dbContext.Cities
                      .Include(c => c.Country)
                      .Select(new {CityName=c.Name, CountryName=c.Country.Name}
                      .ToList();
}
This only selects two columns:
SELECT 
   ci.Name as CityName,
   c.Name as CountryName
FROM
  Cities ci
INNER JOIN Countries c 
      ON ci.CountryId = c.CountryId
I hope I could describe it well to you.
  [1]: https://www.entityframeworktutorial.net/lazyloading-in-entity-framework.aspx
