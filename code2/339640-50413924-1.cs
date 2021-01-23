    try
    {
        string path = ""; // You must add the path here. Else it won't work.
        string[] lines = File.ReadAllLines(path);
        foreach(string line in lines)
        {
            Console.WriteLine(line);
        }
    } catch (Exception ex, IOException ioex) {
        // It's optional. You can remove "Exception ex, IOException ioex" if you want. You can delete the code below too.
        Console.WriteLine(ex.ToString());
        Console.WriteLine();
        Console.WriteLine(ioex.ToString());
    } finally
    {
        // in this "finally" section, you can place anything else. "finally" section isn't important, just shows that method has no exceptions.
        // you can add something else like: Console.WriteLine("Code has no exceptions. Great!");
    }
