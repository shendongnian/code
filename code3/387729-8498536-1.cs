    [Table("tblCountries")]
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public static Country Find(MyContext db, int id)
        {
            return db.Countries.Find(id);
        }
        public static Country Find(MyContext db, string CountryName)
        {
            var matches = from c in db.Countries where c.Name == CountryName select c;
            if (matches.Count() > 0)
            {
                return matches.First();
            }
            else
            {
                return null;
            }
        }
    }
