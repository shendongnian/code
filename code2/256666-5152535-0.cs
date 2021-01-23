        class SoapExtAttribute : SoapExtensionAttribute
        {
            int priority = 0;
    
            public override Type ExtensionType
            {
                get { return typeof(SoapExt); }
            }
    
            public override int Priority
            {
                get
                {
                    return priority;
                }
                set
                {
                    priority = value;
                }
            }
        }
