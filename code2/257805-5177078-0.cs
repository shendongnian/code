      public class A
      {
        virtual public Rectangle getRectangle()
        {
          return [some rectangle];
        }
        public bool collision(A other)
        {
          Rectangle rect1 = getRectangle();
          Rectangle rect2 = other.getRectangle();
          return rect1.Intersects(rect2);
        }
      }
      public class B : A
      {
         override public Rectangle getRectangle()
         { 
            return [some other rectangle];
         }
       }
