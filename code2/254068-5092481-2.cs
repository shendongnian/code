    [TestFixture] 
        public class TestExample 
        {      
        
        [RowTest]      
        [Row( 1)]      
        [Row( 2)]      
        [Row( 3)]      
        [Row( 4)]      
        
        public void TestMethodExample(int value)      
        {           
                  ...
                  ...
                  ...
                  Assert.IsTrue("some condition ..");
        } 
     } 
