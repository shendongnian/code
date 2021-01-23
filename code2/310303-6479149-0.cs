      public class Parent 
      {
        public int x;
        public Parent() 
        {
          x = 3;
        }
      }
    
      public class Child : Parent 
      { 
        public Child() 
        { 
          Console.WriteLine("Child Constructor. x="+x.ToString()); 
        } 
      }
