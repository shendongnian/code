    //classes.cs
    public class RootObject
    {
        public List<List> list { get; set; }
    }
    
    public class List
    {
        public Main main { get; set; }
    }
    
    public class Main
    {
        public double temp { get; set; }
    }
    
    //API client
    using Newtonsoft.Json;
    
    var object = JsonConvert.DeserializeObject<RootObject>(test); //test is JSON response as string 
    
    foreach(item in list){
      var temp = item.main.temp;
    }
    
    //Hope it helps
