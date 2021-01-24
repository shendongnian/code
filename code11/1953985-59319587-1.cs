    public class Child
    {
        // some code
    
        public Worker Parent { get; set; }
    
        // This is called when the process fails
        public void Notify()
        {
            Parent.GetFaulty(this);
        }
    
        // more code
    }
    public class Worker
    {
        private List<Child> subscriptions = new List<Child>();
        public void Subscribe(string pID)
        {
            Child temp = new Child { Parent = this };
            subscriptions.Add(temp);
        }
        public void GetFaulty(Child faulty)
        {
            subscriptions.Remove(faulty);
        }
    }
