    public class Country
    {
        public   string ShortName {get;set;}
        public int ID {get;set;}
        public string LongName { get; set; }
    }
    
    public class Countries
    {
       static  Dictionary<string, Country> dict = new Dictionary<string, Country>();
       public static void Add(Country country)
       {
           if (!dict.ContainsKey(country.ShortName))
               dict.Add(country.ShortName, country);
       }
       public static Country GetByShortName(string ShortName)
       {
           if (dict.ContainsKey(ShortName))
               return dict[ShortName];
           return null;
       }
       public static Country GetById(int id)
       {
           var result = from country in dict
                        where country.Value.ID==id
                        select new Country
                        {
                            ID = country.Value.ID,
                            ShortName = country.Value.ShortName,
                            LongName = country.Value.LongName
                        };
           return result.SingleOrDefault();
       }
       public static List<Country> GetAll()
       {
           var result = from country in dict
                        select new Country
                        {
                            ID = country.Value.ID,
                            ShortName = country.Value.ShortName,
                            LongName = country.Value.LongName
                        };
           return result.ToList();
       }
    }
