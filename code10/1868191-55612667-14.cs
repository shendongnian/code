        private string[] _values;
        public bool Read()
        {
            var ok = _inner.Read();
            if (ok)
            {
                //It *could be null*
                if (_inner.IsDBNull(0))
                {
                    //What to do? Store an empty array for now
                    _values = new string[0];
                }
                var fieldValue = _inner.GetString(0);                
                _values= fieldValue.Split(',');
            }
            return ok;
        }
