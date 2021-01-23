    class Cro
    {
         public Cro
         {
              _atia="my const value";
         }
         private string _atia; // won't be serialized
         public string Atia //  will be serialized
         {
              get
              {
                   return _atia;
              }
         }
    }
