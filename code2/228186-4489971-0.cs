    class Bar
    {
        [CompilerGenerated]
        private object <Foo>k__BackingField;
    
        public object Foo
        {
            [CompilerGenerated]
            get
            {
                return this.<Foo>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<Foo>k__BackingField = value;
            }
        }
    }
