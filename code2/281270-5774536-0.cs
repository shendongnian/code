    class StorageClassName : Dictionary<string, double[]>
    {}
    class DynamicStorageClassName : DynamicObject
    {
        private readonly StorageClassName m_storageClassName;
        public DynamicStorageClassName(StorageClassName storageClassName)
        {
            m_storageClassName = storageClassName;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (m_storageClassName.ContainsKey(binder.Name))
            {
                result = m_storageClassName[binder.Name];
                return true;
            }
            return base.TryGetMember(binder, out result);
        }
    }
