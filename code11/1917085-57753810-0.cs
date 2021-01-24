    public class CityModel
    {
       public int CityId { get; set; }
       public string CityName { get; set; }
       public override string ToString()
       {
           return CityName;
       }
    }
    public class CountyModel
    {
       public int CountyId { get; set; }
       public string CountyName { get; set; }
       public override string ToString()
       {
           return CountyName;
       }
    }
