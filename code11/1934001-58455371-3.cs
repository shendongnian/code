    public class Program
    {
        private static DirectoryInfo _maindirectory = new DirectoryInfo("C:\\Users");
        private static Dictionary<string, Func<string>> _keyaction =
            new Dictionary<string, Func<string>>
            {
                {"lf", ListFiles},
                {"ld", ListDirectories},
                {"cd", ChangeDirectory},
                {"exit", Exit}
            };
        private static string _value;
        private static void DisplayPrompt(FileSystemInfo directory)
        {
            Console.Write($"{directory?.FullName ?? "[cmd]"}: ");
        }
        private static void ProcessAnswer(IReadOnlyList<string> array)
        {
            var action = array.Count > 0 ? array[0] : string.Empty;
            _value = array.Count > 1 ? array[1] : null;
            Func<string> method;
            _keyaction.TryGetValue(action, out method);
            if (method == null)
            {
                WriteError($"Unknown command: {action}");
            }
            else
            {
                Console.WriteLine(_keyaction[action].Invoke());
            }
        }
        private static string ListFiles()
        {
            var dir = Directory.Exists(_value) ? new DirectoryInfo(_value) : _maindirectory;
            foreach (var file in dir.GetFiles())
            {
                Console.WriteLine(file.Name);
            }
            return "ok";
        }
        private static string ListDirectories()
        {
            var dir = Directory.Exists(_value) ? new DirectoryInfo(_value) : _maindirectory;
            foreach (var directory in dir.GetDirectories())
            {
                Console.WriteLine(directory);
            }
            return "ok";
        }
        private static string ChangeDirectory()
        {
            if (Directory.Exists(_value))
            {
                _maindirectory = new DirectoryInfo(_value);
            }
            else if (Directory.Exists(Path.Combine(_maindirectory.FullName, _value)))
            {
                _maindirectory = new DirectoryInfo(
                    Path.Combine(_maindirectory.FullName, _value));
            }
            else
            {
                WriteError("Directory not found.");
            }
            return "ok";
        }
        private static void WriteError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static string Exit()
        {
            Environment.Exit(0);
            return "ok";
        }
        private static void Main()
        {
            while (true)
            {
                DisplayPrompt(_maindirectory);
                ProcessAnswer(Console.ReadLine()?.Split(' '));
            }
        }
    }
