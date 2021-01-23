    #region schedule column collection
    [PersistChildren(true)]
    public sealed class ScheduleGridColumnCollection : ICollection
    {
        #region member variables
        private ArrayList ItemArray;
        private string columnGroupTitle;
        #endregion
        #region constructors
        public ScheduleGridColumnCollection(ArrayList items)
        {
            ItemArray = items;
        }
        #endregion
        #region methods
        /// <summary>
        /// Finds the column corresponding to the data field.
        /// </summary>
        /// <param name="DataFieldName"></param>
        /// <returns></returns>
        public ScheduleGridColumn FindColumnDataField(string dataFieldName)
        {
            ScheduleGridColumn column = new ScheduleGridColumn();
            foreach (ScheduleGridColumn item in ItemArray.Cast<ScheduleGridColumn>())
            {
                if (item.DataField == dataFieldName)
                {
                    column = item;
                    break;
                }
            }
            return column;
        }
        public bool ContainsColumnWithDataField(string dataFieldName)
        {
            foreach (ScheduleGridColumn item in ItemArray.Cast<ScheduleGridColumn>())
                if (item.DataField == dataFieldName)
                    return true;
            return false;
        }
        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item"></param>
        public void Add(ScheduleGridColumn item)
        {
            ItemArray.Add(item);
        }
        public void AddRange(ScheduleGridColumnCollection itemCollection)
        {
            foreach (ScheduleGridColumn item in itemCollection)
                ItemArray.Add(item);
        }
        /// <summary>
        /// Clears all items from the collection.
        /// </summary>
        public void Clear()
        {
            ItemArray.Clear();
        }
        /// <summary>
        /// Returns the enumerated equivalent of the collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return ItemArray.GetEnumerator();
        }
        /// <summary>
        /// Copies the collection to the array parameter.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="index"></param>
        public void CopyTo(Array array, int index)
        {
            ItemArray.CopyTo(array, index);
        }  
        #endregion
        #region properties
        /// <summary>
        /// Gets the schedule column located at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ScheduleGridColumn this[int index]
        {
            get
            {
                return (ScheduleGridColumn)ItemArray[index];
            }
        }
        /// <summary>
        /// Gets a schedule column from the collection based on a unique name.
        /// </summary>
        /// <param name="uniqueName"></param>
        /// <returns></returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ScheduleGridColumn this[string uniqueName]
        {
            get
            {
                ScheduleGridColumn dataColumn = null;
                foreach (object item in ItemArray)
                    if (((ScheduleGridColumn)item).UniqueName == uniqueName)
                        dataColumn = (ScheduleGridColumn)item;
                return dataColumn;
            }
        }
        /// <summary>
        /// Gets the total number of items in the collection.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Count
        {
            get
            {
                return ItemArray.Count;
            }
        }
        /// <summary>
        /// Gets a value indicating whether the collection is read only.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Gets a value indicating whether the collection is synchronized.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Gets the sync root object.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SyncRoot
        {
            get
            {
                return this;
            }
        }
        /// <summary>
        /// Gets or sets the column group title.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public string ColumnGroupTitle
        {
            get
            {
                return columnGroupTitle;
            }
            set
            {
                columnGroupTitle = value;
            }
        }
        #endregion
    }
    #endregion
