        static void Main(string[] args)
        {
            string json = @"[{name: 'firstPageNumber',
                value: '1',
                label: 'Start page numbering at'},
                {name: 'documentstart',
                value: [1,2,3],
                label: 'Document start'}]";
            var obj = JsonConvert.DeserializeObject<List<Input>>(json);
            Console.WriteLine(obj[0].value is JArray);
            Console.WriteLine(obj[2].value is JArray);
            Console.WriteLine(JsonConvert.SerializeObject(obj));
            Console.ReadKey();
        }
    }
    public class Input
    {
        public string name { get; set; }
        public object value { get; set; }
        public string label { get; set; }
    }
