     Demo demo = new Demo
            {
                a = new A
                {
                    x = "test data",
                },
                b = new B
                {
                    y = "test data",
                },
                c = new C[]
                {
                    new C
                    {
                        z = "hello",
                        d = new D
                        {
                            p = "This is D's property"
                        }
                    },
                    new C
                    {
                        z = "Hi",
                        d = new D
                        {
                            p = "Another D's property"
                        }
                    },
                }
            };
