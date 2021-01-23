    public class MyControl : Control
    {
        public class MyControlProperties
        { 
            public string Prop1 { get; set; }
            public int Prop2 { get; set; }
        }
    
        private MyControlProperties props;
    
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public MyControlProperties Properties
        {
            get
            {
                if(props == null) props = new MyControlProperties();
    
                return props;
            }
        }
    }
