    public class MyDataModelObject
    {
        public int NotBindableProperty { get; }
    
        [MyBindableAttribute]
        public string BindableStringProperty
        {
            get {...}
            set {...}
        }
    }
