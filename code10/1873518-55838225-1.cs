    public class HealthCheck
    {
       // here
       public HealthCheck()
       {
       }
       public HealthCheck(string title, string hctype, string link)
       {
           Title = title;
           HCType = hctype;
           Link = link;
       }
       public int Id { get; set; }
       public string Title { get; set; }
       public string HCType { get; set; }
       public string Link { get; set; }
    
    }
