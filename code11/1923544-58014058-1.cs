Text length: 15882
Character position: 11912
Standard loop (inline):                    <b>00:00:00.1429526 (10000 à 00:00:00.0000142)</b>
Standard loop (inline unsafe):             00:00:00.1642801 (10000 à 00:00:00.0000164)
Standard loop (inline + no short-circuit): 00:00:00.3250843 (10000 à 00:00:00.0000325)
Standard loop (unsafe):                    00:00:00.3605394 (10000 à 00:00:00.0000360)
Standard loop (AggressiveInlining):        00:00:00.3731322 (10000 à 00:00:00.0000373)
Standard loop:                             00:00:00.3859629 (10000 à 00:00:00.0000385)
Regex (Substring):                         00:00:01.8794045 (10000 à 00:00:00.0001879)
Regex (MatchCollection loop):              00:00:02.4916785 (10000 à 00:00:00.0002491)
Resulting line: 284
/* "unsafe" is using pointers to access the string's characters */
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
                Test 1 - Custom loop
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumber((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Custom loop: " + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).ToString() + ")");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 2 - Custom loop (with AggressiveInlining)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumber((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Custom loop (AggressiveInlining): " + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).ToString() + ")");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 3 - Custom loop (with inline check)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumberInline((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Custom loop (inline): " + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).ToString() + ")");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 4 - Custom loop (with inline and no short-circuiting)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumberInline2((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Custom loop (inline + no short-circuit): " + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).ToString() + ")");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 5 - Custom loop (with unsafe check)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumberUnsafe((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Custom loop (unsafe): " + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).ToString() + ")");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Test 6 - Custom loop (with inline + unsafe check)
            */
            sw.Restart();
            for(int x = 0; x < RUNS; x++) {
                numbers.Add(parser.GetLineNumberUnsafeInline((int)(text.Length * 0.75) + r.Next(-4, 4)));
            }
            sw.Stop();
            Console.WriteLine("Line: " + numbers[0]);
            Console.WriteLine("Custom loop (inline unsafe): " + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).ToString() + ")");
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
            Console.WriteLine("Regex (Substring): " + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).ToString() + ")");
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
            Console.WriteLine("Regex (MatchCollection loop): " + sw.Elapsed.ToString() + " (" + numbers.Count + " à " + new TimeSpan(sw.Elapsed.Ticks / numbers.Count).ToString() + ")");
            Console.WriteLine();
            numbers = new List<int>();
            /*
                Tests completed
            */
            Console.Write("All tests completed. Press ENTER to close...");
            while(Console.ReadKey(true).Key != ConsoleKey.Enter);
        }
    }
