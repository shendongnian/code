    public struct Nullable<T> where T : struct
    {
        ....
        public new Type GetType()
        {
            return typeof(Nullable<T>);
        }
    }
