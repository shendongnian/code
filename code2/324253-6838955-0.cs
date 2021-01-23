        class MyClass
        {
            public string Name { get; set; }
            [BrowsableAttribute(false)]
            public string InvisibleProperty { get; set; }
        }
