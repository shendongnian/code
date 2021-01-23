    public class Person
    {
       public string Name {get;set;}
       public int Age {get;set;}
    }
    JavascriptSerializer js= new JavascriptSerializer();
    Person john=js.Desearialize<Person>(json);
