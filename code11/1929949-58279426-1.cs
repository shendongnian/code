internal interface IFileWriter
internal WriterService(IFileWriter fileWriter)
Something like this:
internal interface IWriter
{
	void Write(string text);
}
public class A : IWriter
{
	public void Write(string text) { Console.WriteLine($"A is writing '{text}'"); }
}
public class WriterService
{
	private readonly IWriter x;
	internal WriterService(IWriter x) { this.x = x; }
	public void Write(string text) { x.Write(text); }
}
public class Program
{
	public static void Main(string[] args)
	{
		var s = new WriterService(new A());
		s.Write("Hello!");
	}
}
