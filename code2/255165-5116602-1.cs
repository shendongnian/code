    class ExportColumn
    {
        public ExportColumn (string colHeader, Func<Probleme, object> colGetter)
        {
            Header = colHeader;
            GetValue = colGetter;
        }
    
        public string Header {get; private set;}
        // This function will return the row value for that column for one problem
        public Func<Probleme, object> GetValue {get; private set;}
    }
