        private string _theDataTable="theDataTable";
        private DataTable theDataTable
        {
                get
                {
                        if(ViewState[_theDataTable]==null)
                                return new DataTable();
                        return (DataTable)ViewState[_theDataTable];
                }
                set
                {
                        ViewState[_theDataTable] = value;
                }
        }
