    [ProtoContract(SkipConstructor = true)]
    public class MyClass
    {
        [ProtoMember(3)]
        [XmlIgnore]
        private ProtoDateTime TimestampWrapper { get; set; }
        [ProtoIgnore]
        public DateTime Timestamp
        {
            get
            {
                if (TimestampWrapper == null)
                {
                    TimestampWrapper = new ProtoDateTime();
                }
                return TimestampWrapper.Value;
            }
            set
            {
                TimestampWrapper = new ProtoDateTime { Value = value };
            }
        }
    }
