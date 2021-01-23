    class Foo
    {
        [CompilerGenerated]
        private string <Bar>k__BackingField;
    
        public string Bar
        {
            [CompilerGenerated]
            get
            {
                return this.<Bar>k__BackingField;
            }
            [CompilerGenerated]
            private set
            {
                this.<Bar>k__BackingField = value;
            }
        }
    }
