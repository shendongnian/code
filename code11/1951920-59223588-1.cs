    class Branch : IStatusFieldMarker
    {
        [StatusFieldAttribute]
        public int BranchStatus { get; set; }
    }
    class User : IStatusFieldMarker
    {
        [StatusFieldAttribute]
        public int UserStatus { get; set; }
    }
