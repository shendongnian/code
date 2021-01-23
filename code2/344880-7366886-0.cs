       class Shape
       {
          /* ... */
       }
    
       class CircleShape : Shape
       {
          public static string Name
          {
             get
             {
                return "Circle";
             }
          }
       }
    
       class RectangleShape : Shape
       {
          public static string Name 
          {
             get
             {
                return "Rectangle";
             }
          }
       }
    
       class Program
       {
          static void Main(string[] args)
          {
             var subclasses = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(Shape)));
             foreach (var subclass in subclasses)
             {
                var nameProperty = subclass.GetProperty("Name", BindingFlags.Public | BindingFlags.Static);
                if (nameProperty != null)
                {
                   Console.WriteLine("Type {0} has name {1}.", subclass.Name, nameProperty.GetValue(null, null));
                }
             }
          }
       }
