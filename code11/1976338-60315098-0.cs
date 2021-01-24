    interface IMaster
    {
        void ExecuteMaster();
    }
    class MasterOne : IMaster
    {
        public void ExecuteMaster()
        {
            Console.WriteLine("Master One");
        }
    }
    class MasterTwo : IMaster
    {
        public void ExecuteMaster()
        {
            Console.WriteLine("Master Two");
        }
    }
