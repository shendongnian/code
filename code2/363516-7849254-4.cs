    [Serializable]
    class House:ISerializable
    {
        public string Street {get; set;}
        public string PostalCode {get; set;}
        public int HouseNumber {get; set;}
        public int HouseID {get; set;}
        public string City {get; set;}
        public House() { }
        protected House(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            Street = (string)info.GetValue("Street ", typeof(string));
            PostalCode = (string)info.GetValue("PostalCode", typeof(string));
            HouseNumber = (int)info.GetValue("HouseNumber", typeof(int));
            HouseID = (int)info.GetValue("HouseID", typeof(int));
            City = (string)info.GetValue("City", typeof(string));
        }
        [SecurityPermissionAttribute(SecurityAction.LinkDemand, 
            Flags=SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context) 
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("Street ", Street);
            info.AddValue("PostalCode", PostalCode);
            info.AddValue("HouseNumber", HouseNumber);
            info.AddValue("HouseID", HouseID );
            info.AddValue("City", City);
        }
    }
