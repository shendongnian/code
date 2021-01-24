csharp
using System.IO;
public class MyLocations
{
	public static readonly string App = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
	public static readonly string Templates = Path.Combine(App, "Templates");
}
and in your `Main` you could do something like:
csharp
static void Main(string[] args)
{
  foreach ( var filePath in Directory.EnumerateFiles(MyLocations.Templates) )
  {
	var contents = File.ReadAllText(filePath);
	// do something with "contents"
  }
}
  
This should function properly on a Mac and Linux machine.
