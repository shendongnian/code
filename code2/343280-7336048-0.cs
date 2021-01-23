    public class ThreadOwnedObject : DispatcherObject
    {
        private string field;
        public string ExposedProperty
        {
            get { return field; }
            set
            {
                VerifyAccess(); 
                field = value;
            }
        }
    }
