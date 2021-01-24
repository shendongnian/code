    class DocumentHistory : IComparable<DocumentHistory>
    {
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    
        public int CompareTo(DocumentHistory other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
    
            var thisMostRecentDate = Nullable.Compare(CreatedOn, ModifiedOn) > 0 ? CreatedOn : ModifiedOn;
            var otherMostRecentDate = Nullable.Compare(other.CreatedOn, other.ModifiedOn) > 0 ? other.CreatedOn : other.ModifiedOn;
    
            return Nullable.Compare(otherMostRecentDate, thisMostRecentDate);
        }
    }
