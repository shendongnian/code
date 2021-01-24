csharp
long lines = 0;
var lastSecond = DateTime.Now.Second;
using (var r = new StreamReader("text.txt"))
{
    string line;
    while ((line = r.ReadLine()) != null)
    {
        lines++;
        Console.Title = "Count: " + lines;
        if(lastSecond != DateTime.Now.Second)
            Console.Write("\r{0}   ", Console.Title);
        lastSecond = DateTime.Now.Second;
    }
    Console.WriteLine(""); // Create new line at the end
}
There will be nicer ways to update once per second but the main problem seems to be how to update the current console output.
