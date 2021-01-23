    namespace Premise.Model
    {
        //where T : string, bool, int, float 
        public class PremiseProperty<T>  
        {
            private T _Value;
            public PremiseProperty(String propertyName)
            {
                PropertyName = propertyName;
                UpdatedFromServer = false;
            }
    
            public T Value
            {
                get { return _Value; }
                
                set { _Value = value; }
            }
            public String PropertyName { get; set; }
            public bool UpdatedFromServer { get; set; }
        }
    }
