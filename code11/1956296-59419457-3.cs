    //classes.cs
    public class RootObject
    {
        public List<MyList> list { get; set; }
    }
    
    public class MyList
    {
        public Main main { get; set; }
    }
    
    public class Main
    {
        public double temp { get; set; }
    }
    
    //API client
    using Newtonsoft.Json;
    
    var myobject = JsonConvert.DeserializeObject<RootObject>(test); //test is JSON response as string 
    
    foreach(var item in myobject.list){
      var temp = item.main.temp;
    }
    
    //Hope it helps
