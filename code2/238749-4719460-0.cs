    public class MyWebService 
    {
       [WebMethod]
       public List<string> GetCities() 
       {
          List<string> cities = new List<string>();
          cities.Add("New York");
          cities.Add("San Francisco");
          cities.Add("London");
          return cities;
       }
    }
