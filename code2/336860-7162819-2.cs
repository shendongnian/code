    public class Data<TData, TKey>
    {
        //...
        public void Populate<TOtherKey>(Data<TData, TOtherKey> otherData)
        {
            // copy otherData.Values into my values
        }
    }
