    public class Triangle :Shape {
     public int getSides() {
      return 3;
     }
    }
    
    }
    public class Shape {
     public boolean isSharp(){
      return true;
     }
     public virtual int getSides(){
      return 0 ;
     }
     
     public static void main() {
      Triangle tri = new Triangle();
      System.Console.WriteLine("Triangle is a type of sharp? " + tri.isSharp());  //Inheritance 
      Shape shape = new Triangle();
      System.Console.WriteLine("My shape has " + shape.getSides() + " sides.");   //Polymorphism 
     }
    }
