    static class Extensions
    {
        public DataTable LoadReader(this DataTable dt, IDataReader reader)
        {
            dt.Load(reader);
            return dt;
        }
    }
