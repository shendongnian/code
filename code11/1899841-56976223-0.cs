C#
void Main()
{
	test t = new test();
	var l = new List<test>() {
		new test() {ID = 0, a1="aaa", a2 = 10},
		new test() {ID = 1, a1="aaa", a2 = 40},
		new test() {ID = 2, a1="aaa", a2 = 70},
		new test() {ID = 3, a1="aaa", a2 = 50},
		};
	l.Dump("original");
	l.GroupBy(g => g.a1).Select(s => new { max = s.Max(mm => mm.a2), min = s.Min(mi => mi.a2) }).Dump("return 2 values");
	List<test> lRes = new List<test>();
	lRes.Add(l.OrderBy(o => o.a2).First());
	lRes.Add(l.OrderBy(o => o.a2).Last());
	lRes.Dump("return table of min record and max record");
	
	
}
public class test
{
	public int ID { get; set; }
	public string a1 { get; set; }
	public int a2 { get; set; }
	public test() { }
}
