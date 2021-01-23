    public class MySettingsClass
    {
        public MySettingsClass()
        {
            _property = true;
        }
        private bool _property = true;
        public bool Property 
        {
            get { return _property; }
            set
            {
                if (_property != value)
                {
                    _property = value;
                    this.IsModified = true;
                }
            }
        }
    }
