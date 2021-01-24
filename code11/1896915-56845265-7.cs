     public class Model
     {
         private readonly string _counter;
         private readonly string _name;
         private readonly string _email;
         public Mode(string counter, string name, string email)
         {
             _counter = counter;
             _name = name;
             _email = email;
         }
         public string FormattedData()
         {
             return $"{_counter}. {_name} - {_email}";
         }
     }
