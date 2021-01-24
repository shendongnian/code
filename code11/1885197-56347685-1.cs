      class Program
    {
        static void Main(string[] args)
        {
            string jsonData = @"{  'Timestamp': '2019-05-09T11:24:25.000Z',
	'Channel': 'web',
	'Supplier': 'kunde',
	'Generator': 'survey',
	'Type': 'hudtest',
	'Data': {
		'Alder': '20-29',
		'Køn': 'Kvinde',
		'Hudtype': 'sensitiv',
		'Hudtilstand': 'mixet',
		'materialistID': 61234,
		'Anbefalede produkter': [100225, 725125]
	}
}";
            var b = JsonConvert.DeserializeObject<Rootobject>(jsonData);
            //Console.WriteLine(b.Data.Hudtype);
            //or
            Console.WriteLine(b.Data["Hudtype"]);
            Console.ReadKey();
        }
    }
    public class Rootobject
    {
        public DateTime Timestamp { get; set; }
        public string Channel { get; set; }
        public string Supplier { get; set; }
        public string Generator { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Data { get; set; }
    }
   
