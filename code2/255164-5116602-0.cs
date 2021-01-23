    private struct ExportColumn
    {
        public ExportColumn (string colHeader, Func<Probleme, object> colGetter)
        {
            header = colHeader;
            getValue = colGetter;
        }
    
        public string header;
        // This function will return the row value for that column for one problem
        public Func<Probleme, object> getValue; 
    }
