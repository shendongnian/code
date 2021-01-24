    using System;
    class HelloWorld {
      static void Main() {
    
        var parent = new Parent() { Id = 1, Name = "Parent-A", Age = 56 };
        var child = new  Child(parent); // How to assign object of parent to the child instance here
         child.ChildName = "Child-A";
      }
    }
    
    
    public class Parent 
    {
        public int Id { get; set; }
    
        public string Name { get; set;}
    
        public int Age { get; set; }
    }
    
    public class Child: Parent 
    {
        public Child():base(){
            
        }
        
        public Child(Parent parent):base(){
            this.Id =parent.Id;
            this.Name =parent.Name;
            this.Age =parent.Age;
        }
        public string ChildName { get; set; }
    }
