    [DataContract]
    public class DataObj
    {
        [Required]
        [DataMember(Name = "dataObjectId")]
        public Int64 DataObjectId
        {
            get => (long)DataMembers[nameof(DataObjectId)];
            set => DataMembers[nameof(DataObjectId)] = value;
        }
        [Required]
        [DataMember(Name = "guid")]
        public Guid Guid
        {
            get => (Guid)DataMembers[nameof(Guid)];
            set => DataMembers[nameof(Guid)] = value;
        }
        public Dictionary<string, object> DataMembers { get; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        public DataObj(Int64 dataObjectId, Guid guid)
        {
            DataObjectId = dataObjectId;
            Guid = guid;
        }
        public Dictionary<string, object>.Enumerator Enumerator()
        {
            return DataMembers.GetEnumerator();
        }
    }
