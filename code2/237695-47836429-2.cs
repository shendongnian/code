        class Foo
        {
            [Browsable(false)]
            public string Bar { get; set; }
        }
        void Example()
        {
            SetBrowsableProperty<Foo>("Bar", true);
            Foo foo = new Foo();
            SetBrowsableProperty(foo, "Bar", false);
        }
