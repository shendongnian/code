    public partial class ClassElement
    {
        List<NameType> _nameTypeListClassParams = new List<NameType>();
        public List<NameType> GetNameTypeListValue()
        {
            return _nameTypeListClassParams;
        }
        public void SetNameTypeListValue(List<NameType> value)
        {
            if (value != null)
                _nameTypeListClassParams = value;
        }
    }
