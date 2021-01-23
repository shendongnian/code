    [ProtoContract(SkipConstructor = true)]
    public class ProtoDateTime
    {
        [ProtoIgnore]
        private DateTime? _val;
        [ProtoIgnore]
        public DateTime Value
        {
            get
            {
                if (_val != null)
                {
                    return _val.Value;
                }
                lock (this)
                {
                    if (_val != null)
                    {
                        return _val.Value;
                    }
                    _val = new DateTime(DateTimeWithoutKind.Ticks, Kind);
                }
                return _val.Value;
            }
            set
            {
                lock (this)
                {
                    _val = value;
                    Kind = value.Kind;
                    DateTimeWithoutKind = value;
                }
            }
        }
        [ProtoMember(1)]
        private DateTimeKind Kind { get; set; }
        [ProtoMember(2)]
        private DateTime DateTimeWithoutKind { get; set; }
    }
