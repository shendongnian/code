    internal class StopCreatingPerson : Exception
    {}
    public static string ReadFromConsole()
    {
         var v = Console.ReadLine().ToUpper();
         if (v == "EXIT") { throw new StopCreatingPerson (); }
         return v;
    }
