    public class User 
    { 
        public string Name()
        {
            var m = singleton<main>.instance;
            Console.WriteLine($"Inside User.Name, m.UserId = {m.UserID}");
            return "todo";
        }
    }  
