    using System;
    using System.Linq;
    
    public class Data
    {
        [XmlIgnore()]
        public uint Value { get; set; }
        [XmlAttribute("Value", DataType = "hexBinary")]
        public byte[] ValueBinary
        {
            get
            {
                return BitConverter.GetBytes(Value).Reverse().ToArray();
            }
            set
            {
                Value = BitConverter.ToUInt32(value.Reverse().ToArray(), 0);
            }
        }
    }
