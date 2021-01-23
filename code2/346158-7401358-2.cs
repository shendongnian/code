    public class Place
    {
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new IronJS.Hosting.CSharp.Context();
            string json;
            using (TextReader reader = File.OpenText("array_items.txt"))
            {
                json = reader.ReadToEnd();
            }
            CommonObject result= (CommonObject)ctx.Execute("var x=" + json);
            Dictionary<uint,BoxedValue> indexes = new Dictionary<uint,BoxedValue>();
            result.GetAllIndexProperties(indexes, uint.MaxValue);
            List<Place> places = new List<Place>();
            foreach (uint idx in indexes.Keys)
            {
                Place p = new Place();
                p.ID = (int)idx;
                p.Name = (string)indexes[idx].Object.Members["Name"];
                p.Latitude = (double)indexes[idx].Object.Members["Latitude"];
                p.Longitude = (double)indexes[idx].Object.Members["Longitude"];
                places.Add(p);
            }
            foreach (Place place in places)
            {
                Console.WriteLine("ID = {0}", place.ID);
                Console.WriteLine("Name = {0}", place.Name);
                Console.WriteLine("Latitude = {0}", place.Latitude);
                Console.WriteLine("Longitude = {0}", place.Longitude);
            }
            Console.ReadKey();
        }
    }
