    public class MyChild
    {
        //...
        [XmlIgnore]
        public DateTime Time { get; set; }
        [XmlAttribute("timeUTC")]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public long TimeInt64 
        {
            get { return Date.ToFileTimeUtc(); }
            set { Date = DateTime.FromFileTimeUtc(value); }
        }
    }
