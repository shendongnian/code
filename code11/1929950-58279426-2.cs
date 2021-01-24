internal interface IFileWriter
internal WriterService(IFileWriter fileWriter)
Something like this:
internal interface IWriter
{
	void Write(string text);
}
internal class WriterB : IWriter
{
	public void Write(string text) { Console.WriteLine($"A is writing '{text}'"); }
}
internal class WriterA : IWriter
{
	public void Write(string text) { Console.WriteLine($"B is writing '{text}'"); }
}
public class WriterService
{
	private readonly IWriter x;
	internal WriterService(IWriter x) { this.x = x; }
	public void Write(string text) { x.Write(text); }
	public static WriterService WithA() { return new WriterService(new WriterA()); }
	public static WriterService WithB() { return new WriterService(new WriterB()); }
}
public class Program
{
	public static void Main(string[] args)
	{
		var s = new WriterService(new WriterA());
		s.Write("Hello!");
		WriterService.WithA().Write("Hello again!");
		WriterService.WithB().Write("And again!");
	}
}
