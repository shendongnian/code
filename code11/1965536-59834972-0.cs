    public class Person {
       public string Name { get; set; }
       public string Address { get; set; }
       public int Age { get; set; } 
       .. 100+ more columns 
    
      public void DoTrim()
      {
          this.Name = this.Name.Trim();
          this.Address = this.Address.Trim();
          ... still need to code 100+ properties
      }
    }
