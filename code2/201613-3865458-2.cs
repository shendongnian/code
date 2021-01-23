    public class Response
    {
        public List<IPolicy> Policies { get; set; }
        
        public void Display()
        {
            Policies.ForEach(p => p.Display());
        }
        public void Display(Type t)
        {
            var policy = (from p in Policies
                          where p.GetType() == t
                          select p).FirstOrDefault();
            policy.Display();
        }
    }
