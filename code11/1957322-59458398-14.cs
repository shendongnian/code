            [Fact]
            public void ListMyObject()
            {
                var list1 = new List<MyObject>
                {
                    new MyObject{ Name = "H" }
                };
                var list2 = new List<MyObject>
                {
                    new MyObject{ Name = "H" }
                };
    
                Assert.Equal(list1, list2); //Passes
            }
