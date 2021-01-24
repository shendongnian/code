.Where(f => new string[] { f.field1, f.field2, f.field3 }.Contains("val"));
But I can't say if it's a good idea regarding performance.
Here is an example of the code:
public class ClassWithFields
{
	public int Id { get; set; }
	public string Field1 { get; set; }
	public string Field2 { get; set; }
	public string Field3 {get;set;}
}
public class Program
{
	public static void Main()
	{
		var listFields = new List<ClassWithFields>()
		{
                new ClassWithFields { Id = 1, Field1 = "val", Field2 = "qewr", Field3 = "asdqw" },
                new ClassWithFields { Id = 2, Field1 = "asdf", Field2 = "asdd", Field3 = "asdqw" },
                new ClassWithFields { Id = 3, Field1 = "asdf", Field2 = "qewr", Field3 = "val" }
        };
		var containsVal = listFields.Where(f => new string[] { f.Field1, f.Field2, f.Field3 }.Contains("val"));
		
		foreach (var v in containsVal)
		{
			Console.WriteLine(v.Id);
		}
	}
}
You can run it at https://dotnetfiddle.net/lXSoB4
