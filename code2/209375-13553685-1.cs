    [DataContract]
    class User
    {
        ...
        [DataMember]
        public string MyComplex
        {
             get { return m_MyComplex; }
             set { m_myComplex = (Complex)value; }
        }
        // NOTE that this member is _not_ part of the DataContract
        Complex m_myComplex;
        ...
    }
