    public class SessionObjectDataList<T> : List<T> where T : SessionObjectDataItem
    {
        public SessionObjectDataList<T> DirtyItems
        {
           get
           {
               return this.Where(d => d.IsDirty).ToList();
           }
        }
    }
