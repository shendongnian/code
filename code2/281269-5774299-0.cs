    class BetterStorageClassName : StorageClassName 
    {
        public double[] PropertyName
        {
            get { return this["Property_Name"]; }
            set { this["Property_Name"] = value; }
        }
    }
