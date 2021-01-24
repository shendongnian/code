    interface IAnInterface
    {
        string PropertyX {get;set;}
        string PropertyY {get;set;}
    }
    
    class ClassAAA : IAnInterface
    {
        public string PropertyX {get;set;}
        public string PropertyY {get;set;}
    }
    
    class ClassBBB : IAnInterface
    {
        public string PropertyX {get;set;}
        public string PropertyY {get;set;}
        public string PropertyZ {get;set;}
    }
