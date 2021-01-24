class A {
  public int? a1 {get;}
  public int? a2 {get;}
  (...)
  public int? a301 {get;}
}
I've run a quick test.
I run both options 4 times each.
## Results
if (a.A1 == null || a.A2 == null || a.A2 == null || a.A3 == null || a.A4 == null || a.A5 == null || a.A6 == null || a.A7 == null || a.A8 == null || a.A9 == null || a.A10 == null)
00:00:00.4341559, 00:00:00.4751146, 00:00:00.4799181, 00:00:00.4522816
var sum = a.A1 + a.A2 +a.A3 +a.A4 +a.A5 +a.A6 +a.A7 +a.A8 +a.A9 +a.A10;
if( sum == null )
00:00:00.6336356, 00:00:00.5714210, 00:00:00.6071693, 00:00:00.6795270
## Code
class A
{
	public A(double? a1, double? a2, double? a3, double? a4, double? a5, double? a6, double? a7, double? a8, double? a9, double? a10)
	{
		this.A1 = a1;
		this.A2 = a2;
		this.A3 = a3;
		this.A4 = a4;
		this.A5 = a5;
		this.A6 = a6;
		this.A7 = a7;
		this.A8 = a8;
		this.A9 = a9;
		this.A10 = a10;
	}
	public double? A1 { get; }
	public double? A2 { get; }
	public double? A3 { get; }
	public double? A4 { get; }
	public double? A5 { get; }
	public double? A6 { get; }
	public double? A7 { get; }
	public double? A8 { get; }
	public double? A9 { get; }
	public double? A10 { get; }
}
static void Main(string[] args)
{
	var r = new Random(1);
	var As = Enumerable.Range(0, 1000000)
		.Select(i => new A(
			 r.NextDouble(),
			 r.NextDouble(),
			r.NextDouble(),
			r.NextDouble(),
			r.NextDouble(),
			r.NextDouble(),
			r.NextDouble(),
			r.NextDouble(),
			r.NextDouble(),
			r.NextDouble()
		));
	var index = 0;
	var sw = Stopwatch.StartNew();
	foreach (var a in As)
	{
		if (a.A1 == null || a.A2 == null || a.A2 == null || a.A3 == null || a.A4 == null || a.A5 == null || a.A6 == null || a.A7 == null || a.A8 == null || a.A9 == null || a.A10 == null)
		{
			index++;
		}
		//var sum = a.A1 + a.A2 +a.A3 +a.A4 +a.A5 +a.A6 +a.A7 +a.A8 +a.A9 +a.A10;
		//if( sum == null )
		//{
		//    index++;
		//}
	}
	Console.WriteLine(sw.Elapsed);
}
