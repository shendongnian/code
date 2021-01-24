c#
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("This is some red text");
Console.ResetColor();
Console.WriteLine("This is some boring white text");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("And this is some more red text!");
Console.ResetColor();
OR I could create a function with an input parameter for the text to display red like this:
c#
static void WriteRed(string output){
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(output);
    Console.ResetColor();
}
WriteRed("This is some red text");
Console.WriteLine("This is some boring white text");
WriteRed("And this is some more red text!");
As you can see, we turned this task from a 3 line task, to a 1 line task, which would not be possible without input parameters. This will be very useful in case we need to write in red anywhere else in the program.
Obviously this is a pretty simple example, and in more complex programs this could easily save you 100+ lines.
Another use is for organization. Let's say you have a program that takes user input and processes it in some way. Using functions with input parameters, you can put the user input gathering in one .cs file, and the processing in another.
Parameters are also really useful in constructors, which if you haven't gotten to yet, are just functions that are called when a new instance of an object is created.
