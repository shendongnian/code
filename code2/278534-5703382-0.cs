    public class AnObject
    {
      public Guid Id { get; private set;}
      public DateTime Created {get; private set; }
    
      public AnObject()
      {
        Created = DateTime.Now;
        Id = Guid.NewGuid();
      }
    
      public void PrintToConsole()
      {
        Console.WriteLine("I am an object with id {0} and I was created at {1}", this.Id, this.Created); //note that the the 'this' keyword is redundant
      }
    }
    public Main(string[] args) 
    {
      var obj = new AnObject();
      obj.PrintToConsole();
    }
