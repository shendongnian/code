internal interface IFileWriter
internal WriterService(IFileWriter fileWriter)
Something like this:
internal interface IWriter
{
	void Write(string text)
	{
	}
}
public class A : IWriter
{
	public void Write(string text) {/* write something to Disk */}
}
public class WriterService
{
	private readonly IWriter x;
	internal WriterService(IWriter x)
	{
		this.x = x;
	}
}
