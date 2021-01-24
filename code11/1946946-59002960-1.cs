csharp
using System;
using System.IO;
class Test
{
    static void Main()
    {
        var originalOut = Console.Out;
        Console.SetOut(TextWriter.Null);
        
        LibraryMethod();
        originalOut.WriteLine("This should still go to the console.");
    }
    
    static void LibraryMethod()
    {
        Console.WriteLine("Imagine this were in the referenced package.");
        Console.WriteLine("This isn't going anywhere. It's being discarded.");
    }
}
That does work - but it's pretty annoying. I would personally ask the author of the original package to modify the package if possible - it's pretty odd for a library to write to the console by default. It should at least allow you to specify which `TextWriter` to write to.
