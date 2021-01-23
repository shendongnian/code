    [DataContract]
    class Item
    {
        [DataMember]
        [KnownType(typeof(PropertiesCollection))] //<--- this guy here
        private IEnumerable<KeyValuePair<string, object>> Member1
        {
            get { return this._Properties; }
            set { this._Properties = Value; }
        }
    }
