    public class Survey
    {
       
       public List<Person> Poll;
       public Person p;
    
       public void StartPoll()
       {
           p = new Person();
           p.FullName = "Billy";
           p.LastName = "Bob";
           p.Location = "America";
    	   p.Hobbies = new List<string>(); // This line is missing in your code.
           p.Hobbies.Add("Hiker");// this is where error occurs
           p.Hobbies.Add("Musician");// this is where error occurs
    
           Poll = new List<Person>();
           Poll.Add(p);
    
       }
    
    }
