    [ProtoContract(SkipConstructor = true)]
    public class MyClass
    {
        [ProtoMember(3)]
        [XmlIgnore]
        private ProtoDateTime _timestampWrapper { get; set; }
        [ProtoIgnore]
        public DateTime Timestamp
        {
            get
            {
                return ProtoDateTime.getValue(ref _timestampWrapper);
            }
            set
            {
                return ProtoDateTime.setValue(out _timestampWrapper, value);
            }
        }
        [ProtoMember(4)]
        [XmlIgnore]
        private ProtoDateTime _nullableTimestampWrapper { get; set; }
        [ProtoIgnore]
        public DateTime? NullableTimestamp
        {
            get
            {
                return ProtoDateTime.getValueNullable(ref _nullableTimestampWrapper);
            }
            set
            {
                return ProtoDateTime.setValue(out _nullableTimestampWrapper, value);
            }
        }
    }
