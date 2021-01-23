    namespace NamespaceOfMyDataSet
    {
        public partial class MyDataSet : global::System.Data.DataSet 
        {
            public partial class MyTypedTable : global::System.Data.TypedTableBase<MyTypedTableRow> 
            {
                public System.Data.DataRowCollection GetRows()
                {
                    return this.Rows;
                }
            }
        }
    }
