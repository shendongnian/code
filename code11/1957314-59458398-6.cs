    internal class MyObject
        {
            public char Modifier { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            
        }
    }
        
                [Fact]
                public void ListMyObject()
                {
                    var list1 = new List<MyObject>
                    {
                        new MyObject{ }
                    };
                    var list2 = new List<MyObject>
                    {
                        new MyObject{ }
                    };
        
                    Assert.Equal(list1, list2); // Fails
                }
    
