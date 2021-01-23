    public abstract class GenericBase<T>
    {
        public static int Counter { get; set; }        
    }
    
    public class GenericInt : GenericBase<int>
    {        
    }
    
    public class GenericLong : GenericBase<long>
    {        
    }
    
    public class GenericDecimal : GenericBase<decimal>
    {        
    }
    [TestFixture]
    public class GenericsTests
    {
        [Test]
        public void StaticContextValueTypeTest()
        {
            GenericDecimal.Counter = 10;
            GenericInt.Counter = 1;
            GenericLong.Counter = 100;
           // !! At this point value of the Counter property
           // in all three types will be different - so does not shared across
           // all types
        }
    }
