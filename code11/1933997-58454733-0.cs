static void Main(string[] args)
    {
        maindirectory = new DirectoryInfo("C:/Users");
        keyaction = new Dictionary<string, Func<string>>(); // changed this to an Func instead of a string
        keyaction.Add("lf", ListFiles); // notice I removed the parentheses here
        keyaction.Add("ld", ListDirectories); // and here
        Console.Clear();
        maindirectory = new DirectoryInfo("C:/Users");
        Thread thread = new Thread(new ThreadStart(MainProgramm));
        thread.Start();
    }
and keyaction should be declared like this:
static Dictionary<string, Func<string>> keyaction; // a Func<string> is a function that returns a string and takes no arguments
Then, in your ProcessAnswer method you need to call the function via the reference you have to it in the Dictionary:
 static void ProcessAnswer(string[] array)
    {
        string action = array.GetValue(0).ToString();
        value = array.GetValue(1).ToString();
        string c = keyaction[action](); // calling the referenced funtion
        Console.Write(c);
    }
This should give you the expected result.
In the current state, your program's methods only get called once and then you clear the Console before you can see the output, so it probably looks like your program just says "ok" whenever you enter a command.
