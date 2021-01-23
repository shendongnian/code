    [DataContract]
    [Serializable]
    public class MyData
    {
        private int id_value;
        // Apply the DataMemberAttribute to the property.
        [DataMember]
        public int ID
        {
            get { return id_value; }
            set { id_value = value; }
        }
        public int DontExposeMeToWcf { get; set; }
    }
