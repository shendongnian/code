        private Dictionary<string, int> _someData;
        private Dictionary<string, int> SomeData
        {
            get
            {
                if (_someData == null)
                {
                    _someData = (Dictionary<string, int>)ViewState["someData"];
                    if (_someData == null)
                    {
                        _someData = new Dictionary<string, int>();
                        ViewState.Add("someData", _someData);
                    }   
                }                             
                return _someData;
            }
        }
