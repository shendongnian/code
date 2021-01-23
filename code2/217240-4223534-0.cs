    class Person
    {
       public int ID { get;set; }
       public string Name { get;set; }
    }
    var p = new Person { ID=1, Name="test1" }; //ok
    var another = new Person
        {
           ID = 2,
           Name = "test"+ID         //compile error
        };
    var again = new Person();
    again.ID = 3;
    again.Name = "test"+again.ID; //of course it's correct
  
