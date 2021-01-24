    using System.Collections.Generic;
    using System.Linq;
    
    public class User
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int Time { get; set; }
    }
    
    class Program
    {
        public static void Main(string[] args)
        {
            //This you get from file, no need for this in your code            
            string[] fromFile = new string[5] 
            { "userName1,33,12", "userName2,-55,33", "userName3,34,2", "userName4,23,27", "userName5,63,72" };    
    
            List<User> users = new List<User>();
    
            foreach (string line in fromFile)
            {
                string[] splitLine = line.Split(',');
                users.Add(new User() { Name = splitLine[0], Score = int.Parse(splitLine[1]), Time = int.Parse(splitLine[2]) });    
            }    
    
            foreach (User oneUser in users.OrderByDescending(x => x.Score))
            {
                //Here the store to file or what you want to do
            }
        }
    }
