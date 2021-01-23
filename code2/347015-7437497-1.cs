        public class ZoneCollection : IList<Zone>, IList, ICustomTypeDescriptor
    {
        private IList<Zone> _list = new List<Zone>();
        
        //private IList _list = new ArrayList();
        public ZoneCollection()
        {
            //_list = new ArrayList();
        }
        public int IndexOf(Zone item)
        {
            return _list.IndexOf(item);
        }
        public void Insert(int index, Zone item)
        {
            _list.Insert(index, item);
        }
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }
        public Zone this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                _list[index] = value;
            }
        }
        public void Add(Zone item)
        {
            _list.Add(item);
        }
        public void Clear()
        {
            _list.Clear();
        }
        public bool Contains(Zone item)
        {
            return _list.Contains(item);
        }
        public void CopyTo(Zone[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }
        public int Count
        {
            get { return _list.Count; }
        }
        public bool IsReadOnly
        {
            get { return ((IList)_list).IsReadOnly; }
        }
        public bool Remove(Zone item)
        {
            return _list.Remove(item);
        }
        public IEnumerator<Zone> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        int IList.Add(object value)
        {
            int index = Count;
            Add((Zone)value);
            return index;
        }
        bool IList.Contains(object value)
        {
            return Contains((Zone)value);
        }
        int IList.IndexOf(object value)
        {
            return IndexOf((Zone)value);
        }
        void IList.Insert(int index, object value)
        {
            Insert(index, (Zone)value);
        }
        bool IList.IsFixedSize
        {
            get { return ((IList)_list).IsFixedSize; }
        }
        bool IList.IsReadOnly
        {
            get { return ((IList)_list).IsReadOnly; }
        }
        void IList.Remove(object value)
        {
            Remove((Zone)value);
        }
        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (Zone)value;
            }
        }
        void ICollection.CopyTo(Array array, int index)
        {
            CopyTo((Zone[])array, index);
        }
        bool ICollection.IsSynchronized
        {
            get { return ((ICollection)_list).IsSynchronized; }
        }
        object ICollection.SyncRoot
        {
            get { return ((ICollection)_list).SyncRoot; }
        }
        // Implementation of interface ICustomTypeDescriptor 
        #region ICustomTypeDescriptor impl
        public String GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }
        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }
        public String GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }
        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }
        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }
        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }
        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }
        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }
        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }
        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
        /// <summary>
        /// Called to get the properties of this type. Returns properties with certain
        /// attributes. this restriction is not implemented here.
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }
        /// <summary>
        /// Called to get the properties of this type.
        /// </summary>
        /// <returns></returns>
        public PropertyDescriptorCollection GetProperties()
        {
            // Create a collection object to hold property descriptors
            PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);
            // Iterate the list of zones
            for (int i = 0; i < this._list.Count; i++)
            {
                // Create a property descriptor for the zone item and add to the property descriptor collection
                ZoneCollectionPropertyDescriptor pd = new ZoneCollectionPropertyDescriptor(this, i);
                pds.Add(pd);
            }
            // return the property descriptor collection
            return pds;
        }
        #endregion
    }
    /// <summary>
    /// Summary description for CollectionPropertyDescriptor.
    /// </summary>
    public class ZoneCollectionPropertyDescriptor : PropertyDescriptor
    {
        private ZoneCollection collection = null;
        private int index = -1;
        public ZoneCollectionPropertyDescriptor(ZoneCollection coll, int idx) :
            base("#" + idx.ToString(), null)
        {
            this.collection = coll;
            this.index = idx;
        }
        public override AttributeCollection Attributes
        {
            get
            {
                return new AttributeCollection(null);
            }
        }
        public override bool CanResetValue(object component)
        {
            return true;
        }
        public override Type ComponentType
        {
            get
            {
                return this.collection.GetType();
            }
        }
        public override string DisplayName
        {
            get
            {
                Zone zone = (Zone)this.collection[index];
                return zone.ID.ToString();
            }
        }
        public override string Description
        {
            get
            {
                Zone zone = (Zone)this.collection[index];
                StringBuilder sb = new StringBuilder();
                sb.Append(zone.ID.ToString());
                if (zone.Streets.Route != String.Empty || zone.Streets.Crossing != String.Empty)
                    sb.Append("::");
                if (zone.Streets.Route != String.Empty)
                    sb.Append(zone.Streets.Route);
                if (zone.Streets.Crossing != String.Empty)
                {
                    sb.Append(" and ");
                    sb.Append(zone.Streets.Crossing);
                }
                return sb.ToString();
            }
        }
        public override object GetValue(object component)
        {
            return this.collection[index];
        }
        public override bool IsReadOnly
        {
            get { return false; }
        }
        public override string Name
        {
            get { return "#" + index.ToString(); }
        }
        public override Type PropertyType
        {
            get { return this.collection[index].GetType(); }
        }
        public override void ResetValue(object component)
        {
        }
        public override bool ShouldSerializeValue(object component)
        {
            return true;
        }
        public override void SetValue(object component, object value)
        {
            // this.collection[index] = value;
        }
    }
