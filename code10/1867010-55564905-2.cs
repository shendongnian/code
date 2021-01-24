        private static void FireCanons(int time)
        {
            // A Dictionary That Will Hold Our Results.
            var myList = new Dictionary<int, string>
            {
                { 1, "do something" },
                { 2, "do something else" },
                { 3, "you probably get the point" },
                { 4, "My real problem is much longer than this. This is just. an. example" }
            };
            // Check If the Time (Key) Exits
            if (myList.ContainsKey(time))
            {
                // Attempt To Get The Value.
                if (myList.TryGetValue(time, out string result))
                {
                    // Display Results.
                    Console.WriteLine(result);
                }
            }
        }
