    [DataContract]
    [KnownType(typeof(PropertiesCollection))] //<--- this guy here
    class Item
    {
        [DataMember]
        private IEnumerable<KeyValuePair<string, object>> Member1
        {
            get { return this._Properties; }
            set { this._Properties = Value; }
        }
    }
