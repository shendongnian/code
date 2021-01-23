    Include 'MbUnit.Framework.TestSequence(1)' and use ProcessTextFixture instead  of TextFixture.
      [ProcessTextFixture]
     public class TestSequeunce
    {
        
        [MbUnit.Framework.TestSequence(1)]
        [TEST]
        public void TestMethod1()
        {
        }
        
        [MbUnit.Framework.TestSequence(2)]
        [TEST]
        public void TestMethod1()
        {
        }`enter code here`
    }
