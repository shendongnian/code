    class Cro
    {
         private string _atia; // won't be serialized
         public string Atia //  will be serialized
         {
              get
              {
                   return _atia;
              }
              set
              {
                   _atia=value;
              }
         }
    }
