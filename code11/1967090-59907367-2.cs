        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new DataObject();
            }
        }
    
        public class EDetails
        {
    
            [JsonProperty("title")]
            public string Title { get; set; }
    
            [JsonProperty("value1")]
            public string Value1 { get; set; }
    
            [JsonProperty("objects")]
            public Object Objects { get; set; }
    
            [JsonProperty("lists")]
            public List<List> Lists { get; set; }
        }
    
        public class Object
        {
            [JsonProperty("obj1")]
            public string Obj1 { get; set; }
    
            [JsonProperty("obj2")]
            public string Obj2 { get; set; }
        }
    
        public class List
        {
            [JsonProperty("date")]
            public string Date { get; set; }
    
            [JsonProperty("time")]
            public string Time { get; set; }
        }
        public class DataObject
        {
    
            public IList<string> NewDateTimeList { get; set; }
    
            public DataObject()
            {
    
                string FilePath = @"C:\Users\Win10EGL\source\repos\Test\testJson.json";
    
                var rootObject = JsonConvert.DeserializeObject<EDetails>(File.ReadAllText(FilePath));
    
                NewDateTimeList = new List<string>();
                foreach (var element in rootObject.Lists.ToList())
                {
    
                    NewDateTimeList.Add(element.Date + " " + element.Time);
                }
            }
        }
