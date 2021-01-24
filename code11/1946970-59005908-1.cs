cs
    public class Country
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public static List<Country> Parse(string[] objects)
        {
            List<Country> countries = new List<Country>();
            foreach (string obj in objects)
            {
                try
                {
                    string[] tokens = obj.Split(',');
                    string[] first_portion_tokens = tokens[0].Split(' ');
                    countries.Add(new Country()
                    {
                        Number = int.Parse(first_portion_tokens[0]),
                        Name = string.Join(" ", first_portion_tokens.Skip(1).ToArray()),
                        Continent = tokens[1].Trim()
                    });
                }
                catch (System.Exception)
                {
                    // invalid token
                }
            }
            return countries;
        }
    }
and use it like this:
cs 
    string[] myObjects = new string[] { "123 USA, America" , "126 South Africa, Africa" };
    List<Country> countries = Country.Parse(myObjects);
