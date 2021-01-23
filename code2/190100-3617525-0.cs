    public class Data
    {
        internal Data()
        {
            // internal constructor cannot be called from outside the assembly
        }
        // properties, fields and methods
    }
    public class Provider
    {
        public Data GetData()
        {
            return new Data();
        }
    }
