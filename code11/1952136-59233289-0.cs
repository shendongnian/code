    public Class MyDataType 
    {
        publig int id {
            get {
                // Some actual code
                return this.GetHashCode() * 2;
            }
        }
    }
