    var timer = new System.Timers.Timer(1000);
    // Your CSV reading might happen in here.
    List<string> lines = ReadFromCsv();
    int lineNumer = 0;
    timer.Elapsed += (sender, e) =>
        {
            if (lineNumer >= lines.Count)
            {
                timer.Enabled = false;
            }
            else
            {
                string line = lines[lineNumer++];
                string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    // Print every part with width 10 left-justified.
                    Console.Write("{0,-10}", part);
                }
                Console.WriteLine();
            }
        };
    timer.Start();
