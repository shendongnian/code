    public interface IDep1
    {
        IEnumerable<int> GetSomeList(int);
    }
    
    public interface IDep2
    {
        int DoSomeProcessing(int);
    }
    
    public class MockDepdency1 : IDep1
    {
        public IEnumerable<int> GetSomeList(int val)
        {
            return new int[]{ 1, 2, 3 }.AsEnumerable();
        }
    }
    
    public class MockDepdency2 : IDep2
    {
        public int DoSomeProcessing(int val)
        {
            return val + 1;
        }
    }
    
    ...
    main()
    {
        IDep1 dep1 = new MockDependency1();
        IDep2 dep2 = new MockDependency2();
    
        var proc = new Processor(dep1, dep2);
        var actual = proc.Process(5);
    
        Assert.IsTrue(actual.Count() == 3);
    }
