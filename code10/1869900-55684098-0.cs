csharp
public List<string> ReadFile()
{
    StreamReader myReader = new StreamReader("groceries.txt");
    List<string> list = new List<string>(); // Create an empty list of strings
    while (myReader.Peek() >= 0) // Checks if the stream has reacht the end of the file.
    {
        list.Add(myReader.ReadLine()); // Reads a line out of the files and appends it to the list.
    }
    return list; // Returns the list from the method.
}
With these changes you also need to adjust your `writeFile` method, like so:
csharp
public void WriteFile()
{
    List<string> lines = ReadFile();
    // Calls ReadFile to get the already exsisting lines from the file.
    lines.Add("Grocery for you"); // You can add new lines now.
    lines.Add(DateTime.Now.ToString());
    StreamWriter file = new StreamWriter("c:\\MicrosoftVisual\\invoice.txt");
    foreach (string line in lines)
    {
        file.WriteLine(line);
    }
    file.Flush(); // You only need to call Flush once when you are finished writing to the Stream.
}
There is even a simpler variant without `Stream`s by using C#'s `File` helper class.
csharp
List<string> lines = new List<string>(File.ReadAllLines("groceries.txt"));
// Reads all lines from the file and puts them into the list.
lines.Add("Grocery for you"); // You can add new lines now.
lines.Add(DateTime.Now.ToString());
File.WriteAllLines("c:\\MicrosoftVisual\\invoice.txt", lines);
