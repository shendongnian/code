    enum ComparisonState
    {
        Unchanged,
        Changed,
        New,
        Deleted
    }
    sealed class ComparedData
    {
        public Data            Data            { get; }
        public int             PreviousAmount  { get; }
        public ComparisonState ComparisonState { get; }
        public ComparedData(Data data, ComparisonState comparisonState, int previousAmount)
        {
            Data            = data;
            ComparisonState = comparisonState;
            PreviousAmount  = previousAmount;
        }
        public override string ToString()
        {
            if (ComparisonState == ComparisonState.Changed)
                return $"Serial: {Data.Serial}, Amount: {PreviousAmount}, New amount: {Data.Amount}, Status: Changed";
            else
                return $"Serial: {Data.Serial}, Amount: {Data.Amount}, Status: {ComparisonState}";
        }
    }
