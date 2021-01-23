    interface ICustAction
    {
        void Execute();
    }
    
    interface ICustActionCollection : ICustAction
    {
        List<ICustAction> Actions { get; }
    
        List<ICustAction> GetAllActions();
    
        void ExecuteDistinct();
    
        bool HasDuplicates();
    }
