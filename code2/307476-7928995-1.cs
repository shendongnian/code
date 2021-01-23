    [ComVisible(true)]
    [Guid("YYYYYYYY-YYYY-YYYY-YYYY-YYYYYYYYYYYY")]
    [ProgId("COMLIB.DynamicModel")]
    [ClassInterface(ClassInterfaceType.None)]
    public sealed class DynamicModel : DynamicObject, IDynamicModel
    {
        #region indexer
        public dynamic this[string propertyName]
        {
            get
            {
                dynamic propertyValue;
                if (TryGetMember(propertyName, out propertyValue) != true)
                {
                    propertyValue = null;
                }
                return propertyValue;
            }
            set
            {
                if (TrySetMember(propertyName, value) != true)
                {
                    throw new ArgumentException("Cannot set property value");
                }
            }
        }
        #endregion indexer
        #region Fields
        private DataRow dataRow;
        #endregion Fields
        #region Properties
        public dynamic GetAsDynamic { get { return this; } }
        #endregion Properties
        #region CTOR Methods
        public DynamicModel()
            : base()
        {
            DataTable dataTable = new DataTable();
            this.dataRow = dataTable.NewRow();
        }
        public DynamicModel(DataRow dataRow)
            : base()
        {
            this.dataRow = dataRow;
        }
        #endregion CTOR Methods
        #region Dynamic Object Member Overrides
        public override bool TryGetMember(GetMemberBinder binder, out object columnValue)
        {
            bool result = false;
            columnValue = null;
            result = TryGetMember(binder.Name, out columnValue);
            return result;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            bool result = false;
            result = TrySetMember(binder.Name, value);
            return result;
        }
        #endregion Dynamic Object Member Overrides
        #region Operations
        
        public bool TryGetMember(string columnName, out dynamic columnValue)
        {
            bool result = false;
            columnValue = null;
            if (dataRow != null && dataRow.Table.Columns.Contains(columnName))
            {
                columnValue = dataRow[columnName];
                result = true;
            }
            return result;
        }
        public bool TrySetMember(string columnName, dynamic columnValue)
        {
            bool result = false;
            if (dataRow != null && dataRow.Table.Columns.Contains(columnName) == true)
            {
                dataRow[columnName] = columnValue;
                result = true;
            }
            else
            {
                Type type = columnValue.GetType();
                DataColumn dataColumn = new DataColumn(columnName, type);
                result = TrySetDataColumn(dataColumn, type, columnValue);
            }
            return result;
        }
        private bool TrySetDataColumn(DataColumn dataColumn, Type type, object value)
        {
            bool result = false;
            dataRow.Table.Columns.Add(dataColumn);
            result = TrySetMember(dataColumn.ColumnName, value);
            return result;
        }
        #endregion Operations
    }
