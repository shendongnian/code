    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class MyClass {
        private Dictionary<string,object> backingStore = new Dictionary<string,object>();
        public object GetPropertyValue(string propertyName) {
            if (backingStore.ContainsKey(propertyName))
                return backingStore[propertyName];
            else
                return null;
        }
        public void SetPropertyValue(string propertyName, object value) {
            if (value == DBNull.Value) value = null;
            if (backingStore.ContainsKey(propertyName))
                backingStore[propertyName] = value;
            else
                backingStore.Add(propertyName, value);
        }
        [ComVisible(false)]
        public DateTime? MyDate {
            get {
                return GetPropertyValue(@"MyDate") ?? default(DateTime?);
            }
            set {
                SetPropertyValue(@"MyDate", value);
            }            
        }
    }
