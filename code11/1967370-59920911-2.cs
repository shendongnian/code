    public class Transfer
    {
        ...
        public int OriginClubId { get; set; }
        public int DestinationClubId { get; set; }
        public virtual Club OriginClub { get; set; }
        public virtual Club DestinationClub { get; set; }
        ...
    }
