    interface ILimit
    {
        int PostLimit { get; protected set; }
        bool IsLimitReached(int postCount);
    }
