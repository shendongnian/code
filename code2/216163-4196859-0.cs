    public class MyObject
    {
         public string Name { get; private set; }
         public enum ObjectType { TypeA, TypeB, ... }
         public MyObject(ObjectType obType)
         {
              switch (obType)
              {
                  case ObjectType.TypeA:
                      Name = "Type A";
                  // and so on
              }
         }
    } 
