    public class MyObject
    {
        [SenstiveData]
        public string PassWord { get; set; }
        public string UserName { get; set; }
    }
    var myObject = new MyObject { PassWord = "I am not to be logged", UserName = "John Galt" };
    var valueToLog = JsonConvert.SerializeObject(myObject, Formatting.Indented, new SenstivieJsonConverter(typeof(MyObject)));
