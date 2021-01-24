    class First{
      public Dummy GetData(){
        var dummy = new Dummy(){
        firstName = "james",
        lastName = "jack"
       };
     return dummy;
      }
    }
    class Second{
     var first = new First();
     var myData = first.GetData();
     Console.WriteLine(JsonConvert.SerializeObject(mydata);
    }
