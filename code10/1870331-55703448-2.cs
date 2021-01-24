    public partial class ItemDTO
    {
        public long Vid { get; set; }
        public long PortalId { get; set; }
        public bool IsContact { get; set; }
        public Uri ProfileUrl { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
    
