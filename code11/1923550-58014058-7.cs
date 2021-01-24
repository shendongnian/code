Text length: 15882
Character position: 11912
Standard loop (inline):                    <b>00:00:00.1429526 (10000 à 0.0142 ms)</b>
Standard loop (inline unsafe):             00:00:00.1642801 (10000 à 0.0164 ms)
Standard loop (AggressiveInlining):        00:00:00.3064462 (10000 à 0.0306 ms)
Standard loop (inline + no short-circuit): 00:00:00.3250843 (10000 à 0.0325 ms)
Standard loop (unsafe):                    00:00:00.3605394 (10000 à 0.0360 ms)
Standard loop:                             00:00:00.3859629 (10000 à 0.0385 ms)
Regex (Substring):                         00:00:01.8794045 (10000 à 0.1879 ms)
Regex (MatchCollection loop):              00:00:02.4916785 (10000 à 0.2491 ms)
Resulting line: 284
/* "unsafe" is using pointers to access the string's characters */
----
    class Program
    {
        const int RUNS = 10000;
        static void Main(string[] args)
        {
            string text = "";
            Random r = new Random();
            //Some words to fill the string with.
            string[] words = new string[] { "Hello", "world", "Inventory.MaxAmount 32", "+QUICKTORETALIATE", "TNT1 AABBCC 6 A_JumpIf(ACS_ExecuteWithResult(460, 0, 0, 0) == 0, \"See0\")" };
            
            //Various line endings.
            string[] endings = new string[] { "\r\n", "\r", "\n" };
            /*
                Generate text
            */
            int lineCount = r.Next(256, 513);
            for(int l = 0; l < lineCount; l++) {
                int wordCount = r.Next(1, 4);
                text += new string(' ', r.Next(4, 9));
                for(int w = 0; w < wordCount; w++) {
                    text += words[wordCount] + (w < wordCount - 1 ? " " : "");
                }
                text += endings[r.Next(0, endings.Length)];
            }
            Console.WriteLine("Text length: " + text.Length);
            Console.WriteLine();
            /*
                Initialize class and stopwatch
            */
            TextParser parser = new TextParser(text);
            Stopwatch sw = new Stopwatch();
            List<int> numbers = new List<int>(); //Using a list to prevent the compiler from optimizing-away the "GetLineNumber" call.
            /*
                Test 1 - Standard loop
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumber((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Standard loop: ".PadRight(41) + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).TotalMilliseconds.ToString() + " ms)");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 2 - Standard loop (with AggressiveInlining)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumber2((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Standard loop (AggressiveInlining): ".PadRight(41) + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).TotalMilliseconds.ToString() + " ms)");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 3 - Standard loop (with inline check)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumberInline((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Standard loop (inline): ".PadRight(41) + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).TotalMilliseconds.ToString() + " ms)");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 4 - Standard loop (with inline and no short-circuiting)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumberInline2((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Standard loop (inline + no short-circuit): ".PadRight(41) + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).TotalMilliseconds.ToString() + " ms)");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 5 - Standard loop (with unsafe check)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumberUnsafe((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Standard loop (unsafe): ".PadRight(41) + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).TotalMilliseconds.ToString() + " ms)");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 6 - Standard loop (with inline + unsafe check)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumberUnsafeInline((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Standard loop (inline unsafe): ".PadRight(41) + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).TotalMilliseconds.ToString() + " ms)");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 7 - Regex (with Substring)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumberRegex((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Regex (Substring): ".PadRight(41) + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).TotalMilliseconds.ToString() + " ms)");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 8 - Regex (with MatchCollection loop)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumberRegex2((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Regex (MatchCollection loop): ".PadRight(41) + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).TotalMilliseconds.ToString() + " ms)");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Tests completed
            */
            Console.Write("All tests completed. Press ENTER to close...");
            while(Console.ReadKey(true).Key != ConsoleKey.Enter);
        }
    }
