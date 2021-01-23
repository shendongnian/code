    public static class Extensions
    {
        public static void setAdapterTimeout(this SqlDataAdapter da, int timeOut = 120)
        {
            if (da.SelectCommand != null)
                da.SelectCommand.CommandTimeout = timeOut;
            if (da.InsertCommand != null)
                da.InsertCommand.CommandTimeout = timeOut;
        }
    }
