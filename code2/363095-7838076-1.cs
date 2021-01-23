    interface IRental
    {
        ICustomer customer {get;set;}
        string Title { get; set; }
        decimal Cost{ get; set; }
        void Rent();      
    }
