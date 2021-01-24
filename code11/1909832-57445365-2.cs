    public class DisplaySiteTextAttribute : DisplayNameAttribute
    {
        private string _key;
        public DisplaySiteTextAttribute(string key)
        {
            _key = key;
        }
        public override string DisplayName
        {
            get
            {
                return TextManager.GetValue(_key);
            }
        }
    }
