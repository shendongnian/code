    public interface IResult
    {
        // returns true if a test is fulfilled
        bool TestPassed { get; }
        // executes the related action
        void Execute();
    }
