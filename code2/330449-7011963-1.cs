    class StyleProperty<T>
    {
        T _Value;
        bool _UseBackingStore;
        public T Value
        {
            get { return _UseBackingStore ? this._Value : INHERIT; }
            set { this._Value = value; _UseBackingStore = true; }
        }        
    }
