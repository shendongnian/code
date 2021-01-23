    [Serializable]
    public class EncapsulatedData{
        public EncapsulatedData(){}
        public string Message{ get; set; }
        public ISerializable Object{ get; set; }
    }
