        struct test1
        {
            private int? a;
            public int A
            {
                get { return a ?? 25; }
                set { a = value; }
            }
        }
