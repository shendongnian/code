    private class TestData 
    {
    	public DateTime from;
    	public DateTime to;
    }
    public static test()
    {
       Collection<TestData> x = new Collection<TestData>();
       x.Select(item => (item.to - item.from).Hours).Sum();
    }
