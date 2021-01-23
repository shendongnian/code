        //methods
        public void AddIndex(PropertyDescriptor property)
        {
            m_theList.AddIndex(property);
        }
        public object AddNew()
        {
            return m_theList.AddNew();
        }
        //properties
        public bool AllowEdit
        {
            get { return m_theList.AllowEdit; }
        }
 
        ....
        //for events you can use add/remove syntax 
        public event ListChangedEventHandler ListChanged
        {
            add { m_theList.ListChanged += value; }
            remove { m_theList.ListChanged -= value; }
        }
        ....
        //indexer...
        public object this[int index]
        {
            get
            {
                return m_theList[index];
            }
            set
            {
                m_theList[index] = value;
            }
        }
