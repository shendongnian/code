    public class A
    {
    public int Price;
    public int Available;
	public IEnumerable<int> Inv => Enumerable.Repeat(Price, Available);
    }
    var avg1 = items.SelectMany(i => i.Inv).Take(100).Average(); // 10
    var avg2 = items.SelectMany(i => i.Inv).Take(1200).Average(); // 10.8333333333333
