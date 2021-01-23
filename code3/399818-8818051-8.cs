    class ExcelExport : IExport
    {
        private readonly ExcelParams _params;
        public ExcelExport(ExcelParams parameters)
        {
            _params = parameters;
        }
        public void Export() 
        {
            // do stuff
        }
    }
