    using System.Diagnostics.Contracts;
    
    namespace ConsoleApplication1
    {
        class Class1
        {
            public int numberOfAdds    { get; private set; }
            public int numberOfRemoves { get; private set; }
            public int Count
            {
                get
                {
                    return numberOfAdds - numberOfRemoves;
                }
            }
    
            public void Add()
            {
                Contract.Ensures(numberOfAdds == Contract.OldValue(numberOfAdds) + 1);
            }
    
            public void Remove()
            {
                Contract.Requires(Count >= 1);
                Contract.Ensures(numberOfRemoves == Contract.OldValue(numberOfRemoves) + 1);
            }
    
            [ContractInvariantMethod]
            void inv()
            {
                Contract.Invariant(Contract.Result<int>() == numberOfAdds - numberOfRemoves);
            }
        }
    }
