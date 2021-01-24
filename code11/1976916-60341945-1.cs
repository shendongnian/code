    [XmlRoot("Root"),Serializable]
    public class MachineBob 
    {
        [MaxLength(50)]
        [XmlElement("TimeStamp")]
        public DateTime TimeStamp { get; set; }
        [XmlElement("Temperature")]
        [MaxLength(50)]
        public int Temperature { get; set; }
        [MaxLength(50)]
        [XmlElement("Heartbeat")]
        public Boolean Heartbeat { get; set; }
        [MaxLength(50)]
        [ForeignKey("MachineID")]
        public int MachineID { get; set; }
        public Machine Machine { get; set; }
        [MaxLength(50)]
        [ForeignKey("ClientID")]
        public int ClientID { get; set; }
