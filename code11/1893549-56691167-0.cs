    void Main()
    {
    	var tests = new ITest[] { new TestA { A = 1, ID = 0 }, new TestB { B = 10, ID = 1 } };
    	foreach (var test in tests)
    	{
    		test.DoSomeProcessing();
    	}
    }
    
    public interface ITest
    {
    	int ID { get; set; }
    	void DoSomeProcessing();
    }
    
    public class TestA : ITest
    {
    	public int A { get; set; }
    	public int ID { get; set; }
    	public void DoSomeProcessing()
        {
    		Console.WriteLine("A = " + this.A);
    	}
    }
    
    public class TestB : ITest
    {
    	public int B { get; set; }
    	public int ID { get; set; }
    	public void DoSomeProcessing()
    	{
    		Console.WriteLine("B = " + this.B);
    	}
    }
