            public static Expression<Func<LdbRecord, TestClass>> ConvertPoco
            {
                get
                {
                    return p => new TestClass() { Id = p.RecordId, Name = p.RecordName };
                }
            }
