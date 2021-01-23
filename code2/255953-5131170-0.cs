    public class Cat()
    {
      private String _age;
    
        public String Age{
          get{
              return _age;
          }
          set{
               _age = ConvertToHumanYears(value); 
          }
        }
      }
    }
