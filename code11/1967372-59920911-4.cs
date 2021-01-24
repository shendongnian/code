    public Club
    {
        ...
        ICollection<Transfer> OriginTransfers { get; set; }
        ICollection<Transfer> DestinationTransfers { get; set; }
    }
