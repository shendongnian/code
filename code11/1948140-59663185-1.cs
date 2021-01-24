    public class Person{
      public string Name {get; set; }
    }
    static void Main(string[] arg){
      Person.Name = "Federico"; //"need an instance for the non static class Person" error
    } 
