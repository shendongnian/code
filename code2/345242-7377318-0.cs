    interface ICustAction
    {
        void Execute();
    }
    
    interface ICustActionCollection
    {
        List<ICustAction> Actions { get; }
    
        List<ICustAction> GetAllActions();
    
        void ExecuteDistinct();
    
        bool HasDuplicates();
    }
