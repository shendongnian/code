    [DataContract]
    class Class1
    {
        [DataMember]
        public string A { get; set; }
        public Class1()
        {
        }
        public Class2 GetClass2Clone()
        {
            return new Class2(this.A);
        }
    }
    [DataContract]
    class Class2
    {
        [DataMember(Name="A1")]
        public string A { get; set; }
        public Class2(string a)
        {
            this.A = a;
        }
    }
