    [Serializable]
    public class MySerializable
    {
        public string MyProp1 { get; set; }
        public string MyProp2 { get; set; }
        [NonSerialized]
        private IMyNonSerializable _myNonSerializableProp;
        public IMyNonSerializable MyNonSerializableProp
        {
            get { return _myNonSerializableProp; }
            set { _myNonSerializableProp = value; }
        }
    }
