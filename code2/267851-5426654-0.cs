        class Product
        {
            public int ProductNo { get; set; }
            public string ProductName { get; set; }
        }
        class Property
        {
            public int PropertyNo { get; set; }
            public string PropertyName { get; set; }
        }
        class Value
        {
            public int ProductPropertyNo { get; set; }
            public int ProductNo { get; set; }
            public int PropertyNo { get; set; }
            public string Value { get; set; }
        }
