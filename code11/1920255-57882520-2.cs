c#
static void Main(string[] args)
{
    string promptFormat = "{0}: ";
    string[] fieldNames = { "Username", "Password" };
    string[] fieldPrompts = fieldNames.Select(s => string.Format(promptFormat, s)).ToArray();
    int columnWidth = fieldPrompts.Max(s => s.Length);
    Console.Clear();
    foreach (string prompt in fieldPrompts)
    {
        Console.WriteLine(prompt);
    }
    Dictionary<string, string> fieldValues = new Dictionary<string, string>();
    int line = 0;
    foreach (string field in fieldNames)
    {
        Console.SetCursorPosition(columnWidth, line++);
        string userValue = Console.ReadLine();
        fieldValues.Add(field, userValue);
    }
    Console.WriteLine();
    Console.WriteLine("You entered the following:");
    foreach (var kvp in fieldValues)
    {
        Console.WriteLine($"Field: \"{kvp.Key}\", Value: \"{kvp.Value}\"");
    }
}
You would of course need to adapt the user input routine for your password-style input. That level of detail is outside the scope of your actual question, so I didn't bother to include it in the above.
And naturally, you could just hard-code all the locations as well. In fact, that's often how it was done in the olden days too. The code to automatically lay out the user input position is just an easy little tweak to make the code a bit more general purpose. Hopefully you can see how you could include even more automatic-layout features, if you really wanted to.
