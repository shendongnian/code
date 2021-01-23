    class CustAction : ICustAction
    {
        public int ID { get; private set; }
    
        public CustAction(int id)
        {
            ID = id;
        }
    
        public void Execute()
        {
            Console.WriteLine("Execute: {0}", ID);
        }
    }
