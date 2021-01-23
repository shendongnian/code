    [DataContract]
    public class TestClass
    {
        [DataMember]
        public string Val1 { get; set; }
    
        [DataMember]
        public string Val2 { get; set; }
    
        [DataMember]
        public bool NonDefaultBool;
    
        [DataMember]
        public int NonDefaultInt { get; set; }
    		
        private void InitializeDefaults()
        {
            Val1 = "hello";
            NonDefaultBool = true;
            NonDefaultInt = 1234;
        }
    
        #region Construction
    
        public TestClass()
        {
            InitializeDefaults();
        }
    
        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            InitializeDefaults();
        }
    
        #endregion
    }
