    [Serializable]
    public class MetaDataKey<T>
    {
        private Guid id;
        public MetaDataKey(...)
        {
            this.id = Guid.NewGuid();
            ....
        }
        public override bool Equals(object obj)
        {
            var that = obj as MetaDataKey<T>;
            return that != null && this.id == that.id;
        }
    }
