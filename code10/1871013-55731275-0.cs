    class Program
    {
        static void Main(string[] args)
        {
            string json = "{ \"id\": 1, \"name\": \"George Washington\", \"years\": \"1789-1797\" }";
            President president = JsonConvert.DeserializeObject<President>(json);
        }
    }
    public class President
    {
        [JsonProperty("id")] public int Id;
        [JsonProperty("name")] public string Name;
        [JsonProperty("years")] private string _reign
        {
            set
            {
                string[] years = value.Split('-');
                Reign = new Reign
                {
                    StartYear = uint.Parse(years[0]),
                    EndYear = uint.Parse(years[1])
                };
            }
        }
        public Reign Reign;
    }
    public struct Reign
    {
        public uint StartYear;
        public uint EndYear;
    }
