    internal class StopCreatingPersonException : Exception
    {}
    public static string ReadFromConsole(string prompt)
    {
         Write(prompt, false);
         var v = Console.ReadLine().ToUpper();
         if (v == "EXIT") { throw new StopCreatingPerson (); }
         return v;
    }
