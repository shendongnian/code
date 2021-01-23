    interface IIntelligence
    {
        bool intelligent_behavior();
    }
    
    class Human: IIntelligence
    {
        public Human() { }  
    
        /// Interface method definition in the class that implements it
        public bool IIntelligence.intelligent_behavior()
        {
            Console.WriteLine("........");
            return true;
        }    
    
        //Some other method definition
        public bool intelligent_behaviour()
        {
            return false;
        }
    }
