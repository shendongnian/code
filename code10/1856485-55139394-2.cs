    interface IId
    {
        int Id {get;}
    }
    interface IRepositoryEntity : IId
    {
        bool IsObsolete {get;}
        void MarkObsolete();
    }
    
