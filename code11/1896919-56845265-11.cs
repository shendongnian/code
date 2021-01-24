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
         public override string ToString()
         {
             return $"{_counter}. {_name} - {_email}";
         }
     }
     
    // Usage
    var models = dt.AsEnumerable()
        .Select(row => new Model(
            row.Field<string>("counter"), 
            row.Field<string>("name"), 
            row.Field<string>("e-mail")));
    var result = String.Join(", ", models);		
    Console.WriteLine(result);
    // 1. David - David@gmail.com, 2. Ben - Ben@gmail.com, 3. Henry - Henry@gmail.com
     
