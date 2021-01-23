    class Program
    {
        static void ShowMessage(string text, string caption)
            { Console.WriteLine("1"); }
        static void ShowMessage(string formatText, params object[] parms)
            { Console.WriteLine("2"); }
        static void Main(string[] args)
        {
            string myStringFilename = null;
            // Outputs 1
            ShowMessage("Display this message in a Message box",
                        "Caption of Message box");
            // Outputs 1, too. No compiler error
            ShowMessage("Unable to load file {0}", myStringFilename);
        }
    }
