    class Class1
    {
        [ModelBinder(BinderType = typeof(TestModelBinder))]
        public string SampleProperty { get; set; }
    }
