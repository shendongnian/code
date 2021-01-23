     public class EventAlarm
    {
        List<EventProperty> propertyList = null;
        public EventAlarm()
        {
           propertyList = new List<EventProperty>();
        }
        public addProperty(string key, string value)
        {
            propertyList.Add(new EventProperty(key, value));
        }
        public sortProperty()
        {
            propertyList.Sort((x, y)=>x.key.CompareTo(y.key)) 
        }
    }
    private class EventProperty
    {
        #region  Properties
        private string key;
        private string value;
        private bool isPropertyValid;
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
        public string Value
        {
          get { return this.value; }
          set { this.value = value; }
        }
        public bool IsPropertyValid
        {
          get { return isPropertyValid; }
          set { isPropertyValid = value; }
        }
        #endregion  Properties
        #region Constructor
        public EventProperty(string key, string value)
        {
            this.Key = key;
            this.Value = Value;
        }
        #endregion Constructor
        #region Methods
        public void PropertyValidation()
        {
            // Here write Code ...
        }
        #endregion Methods
    }
