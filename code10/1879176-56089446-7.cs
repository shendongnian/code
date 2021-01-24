    public static class AppForms
    {
        private static List<SuperForm> _AppFormsList;
        public static List<SuperForm> AppFormsList
        {
            get
            {
                if (_AppFormsList == null)
                {
                    _AppFormsList = new List<SuperForm>();
                }
                return _AppFormsList;
            }
            set
            {
                _AppFormsList = value;
            }
        }
    
        public static void Add(SuperForm instance)
        {
            AppFormsList.Add(instance);
        }
        public static void Remove(SuperForm instance)
        {
            AppFormsList.Remove(instance);
        }
    }
