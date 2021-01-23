    public static class ApplicationEvents
    {
        public static event EventHandler DataChanged;
    
        public static void NotifyDataChanged()
        {
            EventHandler temp = DataChanged;
            if (temp != null)
            {
                temp(null, EventArgs.Empty);
            }
        }
    }
