    void Main()
    {
        var json = @"{""Test"": {
            ""KIf42N7OJIke57Dj6dkh"": {
                ""name"": ""test 1""
                },
                ""xsQMe4WWMu19qdULspve"": {
                ""name"": ""test 2""
                }
        }
        }";
        
        var root = JsonConvert.DeserializeObject<Root>(json);
        var array = root.Test.Select(i => i.Value).ToArray();
        array.Dump();
    }
    
    public class Root
    {
        public Dictionary<string, Class1> Test { get; set; }
    }
    
    public class Class1
    {
    
        public string Name { get; set; }
    
        public Class1(string name)
        {
            Name = name;
        }
    }
