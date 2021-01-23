    class QueryResult
    {
        private bool _locked;
        // Called after deserialization to lock the object...
        internal void LockDown()
        {
            this._locked = true;
        }
        public String Foo
        {
            get { return this._foo; }
            set 
            {
                if (this._locked)
                    throw new InvalidOperationException();
                this._foo = value;
            }
        }
    }
