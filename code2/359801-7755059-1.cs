        private string _someField;
        public string SomeField
        {
            get 
            {
                // we'd also want to do synchronization if multi-threading.
                if (_someField == null)
                {
                    _someField = new String('-', 1000000);
                }
                return _someField;
            }
        }
