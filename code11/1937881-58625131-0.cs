    Class First{
      public Dummy GetData(){
        var dummy = new Dummy(){
        firstName = "james",
        lastName = "jack"
       };
     return dummy;
      }
    }
    Class Second{
     var first = new First();
     var myData = first.GetData();
     Console.WriteLine(JsonConvert.SerializeObject(mydata);
    }
