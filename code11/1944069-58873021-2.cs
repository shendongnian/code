    public static void Main()
    {
        var data = new []{1,2,3,4,5,6};
        
         var testA = 
             new TestA {
                Label="aa",
                innerList= new List<int>()
             };
        
        ///Err: IEnumerable doesn't contains AddRange
        //testA.innerList.AddRange(data);
        
        
        //as  Alexey commented
        testA.innerList= testA.innerList.Concat(data).ToList();
        testA.innerList.Dump();// Test:  Works
        testA.innerList=new List<int>(); //reset
        
        //Cast      
        ((List<int>)testA.innerList).AddRange(data);        
        testA.innerList.Dump();// Test:  Works  
		// With extention method
		testA.innerList.AddRange(data);	
		testA.innerList.Dump();// Test:  Works	
		testA.innerList=new List<int>(); //reset
        
    }
    
    public class TestA{
        public string Label {get; set;}
        public IEnumerable<int> innerList {get; set;}   
    }
