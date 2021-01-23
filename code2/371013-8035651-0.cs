    namespace MyEx;
    public static class MyExtensions
    {
        public static object SingleValue(this DataSet ds)
        {
            return ds.Tables[0].Rows[0][0];
        }
    }
