cs
// Prefix with >
                Console.Write("> ", Color.Crimson);
                var readInput = Console.ReadLine();
// Don't add a new line if input is empty
                if (string.IsNullOrWhiteSpace(readInput)) {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(new string(' ', Console.WindowWidth)); 
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    continue;
                }
