        const int MaxItems = 5;
        static readonly List<string> ClipboardData = new List<string>();
        public static void SaveClipboard()
        {
            ClipboardData.Add(Clipboard.GetText());
            if (ClipboardData.Count > MaxItems) ClipboardData.RemoveAt(0);
        }
        // You don't need lines later, I show them just as example
        [STAThreadAttribute]
        static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                Clipboard.SetText(i.ToString());
                SaveClipboard();
            }
            foreach (var s in ClipboardData)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
