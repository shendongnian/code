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
        public static DateTime getValue(ref ProtoDateTime wrapper)
        {
            if (wrapper == null)
            {
                wrapper = new ProtoDateTime();
            }
            return wrapper.Value;
        }
        public static DateTime? getValueNullable(ref ProtoDateTime wrapper)
        {
            if (wrapper == null)
            {
                return null;
            }
            return wrapper.Value;
        }
        public static void setValue(out ProtoDateTime wrapper, DateTime value)
        {
            wrapper = new ProtoDateTime { Value = value };
        }
        public static void setValue(out ProtoDateTime wrapper, DateTime? newVal)
        {
            wrapper = newVal.HasValue ? new ProtoDateTime { Value = newVal.Value } : null;
        }
    }
