	public class SomeType1
	{
	  public int Value { get; set; }
	}
	
	public class SomeType2
	{
	  public string Value { get; set; }
	}
	
	public class SomeTypeVisitor
	{
		public void VisitAll(object[] someTypes)
		{
			foreach(var o in someTypes) {
				// this should be in a try-catch block
				Console.WriteLine(((dynamic) o).Value);
			}
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			var someTypes = new object[] {
				new SomeType1() {Value=1},
				new SomeType2() {Value="test"}
			};
	
			var vis = new SomeTypeVisitor();
			
			vis.VisitAll(someTypes);			
		}
	}
