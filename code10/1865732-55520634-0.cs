        private static object _sync = new object();
        private static void UpdatePercentange(ConsoleItem item, double percentage)
        {
			lock(_sync)
			{   
				Console.SetCursorPosition(item.ConsoleLocLeft, item.ConsoleLocTop);
				Console.Write($"({percentage}%)");
			}
        }
