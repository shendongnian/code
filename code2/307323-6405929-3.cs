    class Foo
    {
        public Foo()
        {
            DefaultValueHelper.InitializeDefaultValues(this);
        }
        
        [DefaultValue("(no name)")]
        public string Name { get; set; }
    }
