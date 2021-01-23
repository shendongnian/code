       enum LabelTypeEnum
        {
            something
        }
        class MooClass
        {
            public FooClass Foo { get; set; }
        }
        class FooClass
        {
            public object DangerousNullRef { get; set; }
            public object AnotherPossibleNullRef { get; set; }
        }
        private void Show(Type TrType, LabelTypeEnum LabelType, string p) { }
        private void DontShowField(Type TrType) { }
