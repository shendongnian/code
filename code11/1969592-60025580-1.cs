    // Sample data and result.
    public class A
    {
        public Guid source { get; set; }
        public int refVal { get; set; }   //Name changed from original post
        public string text1 { get; set; }
        public string text2 { get; set; }
        public int Value { get; set; }
    }
    public class B
    {
        public List<Guid> source { get; set; }
        public int refVal { get; set; }     //Name changed from original post
        public List<string> text { get; set; }
        public int Value { get; set; }
    }
    
    var aObjects = new List<A>{new A(){source = new Guid("c3a52882-069a-4fe5-b37f-0ffe00b3299c"),
                  refVal = 100,
                  text1 = "1text1",
                  text2 = "1text2",
                  Value = 10 },
                  new A(){source = new Guid("bcf4cbbf-e01f-48fb-9a45-cc4d9bd5647d"),
                  refVal = 100,
                  text1 = "2text1",
                  text2 = "2text2",
                  Value = 20 },
                  new A(){source = new Guid("9f50a0af-3507-4a2b-be25-842f01372194"),
                  refVal = 100,
                  text1 = "3text1",
                  text2 = "3text2",
                  Value = 30 },
                  new A(){source = new Guid("aed48532-0a92-4093-bbb1-19afe64cef15"),
                  refVal = 101,
                  text1 = "4text1",
                  text2 = "4text2",
                  Value = 40 },
                  new A(){source = new Guid("aed48532-0a92-4093-bbb1-19afe64cef15"),
                  refVal = 101,
                  text1 = "5text1",
                  text2 = "5text2",
                  Value = 50 }};
                  
                  
                  
    //Result : list of B objects stored in aObjects 
    Source : c3a52882-069a-4fe5-b37f-0ffe00b3299c,bcf4cbbf-e01f-48fb-9a45-cc4d9bd5647d,9f50a0af-3507-4a2b-be25-842f01372194
    refVal : 100
    Source : 1text1,2text1,3text1
    Value : 60
    
    Source : aed48532-0a92-4093-bbb1-19afe64cef15
    refVal : 101
    Source : 4text1
    Value : 40
    
    Source : aed48532-0a92-4093-bbb1-19afe64cef15
    refVal : 101
    Source : 5text1
    Value : 50
