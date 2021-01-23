    class StyleProperty<T>
    {
        T _Value;
        public StyleProperty(T inheritedValue)
        {
            _Value = inheritedValue;
        }
        public T Value
        {
            get { return this._Value; }
            set { this._Value = value; }
        }        
    }
