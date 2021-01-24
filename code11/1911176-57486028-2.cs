    public class State
    {
        public string ShortName { get; set; }
        public string FullName { get; set; }
        private string _displayName;
        public string DisplayName
        {
            set
            {
                _displayName = value;
            }
            get
            {
                if (string.IsNullOrEmpty(_displayName))
                    return string.Format("{0} - {1}", ShortName, FullName);
                else
                    return _displayName;
            }
        }
    }
