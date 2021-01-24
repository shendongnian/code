    public class Program
    {
        static DirectoryInfo maindirectory;
        static Dictionary<string, Func<string>> keyaction;
        private static string value;
        static void DisplayPrompt(DirectoryInfo directory)
        {
            Console.Write(directory != null ? "{0}: " : "[cmd]: ", directory.FullName);
        }
        static void ProcessAnswer(string[] array)
        {
            var action = array.Length > 0 ? array[0] : null;
            value = array.Length > 1 ? array[1] : null;
            Func<string> method;
            keyaction.TryGetValue(action, out method);
            if (method == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Unknown command: {action}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(keyaction[action].Invoke());
            }
        }
        static string ListFiles()
        {
            var dir = Directory.Exists(value) ? new DirectoryInfo(value) : maindirectory;
            foreach (var file in dir.GetFiles())
            {
                Console.WriteLine(file.Name);
            }
            return "ok";
        }
        static string ListDirectories()
        {
            var dir = Directory.Exists(value) ? new DirectoryInfo(value) : maindirectory;
            foreach (var directory in dir.GetDirectories())
            {
                Console.WriteLine(directory);
            }
            return "ok";
        }
        static string ChangeDirectory()
        {
            if (Directory.Exists(value))
            {
                maindirectory = new DirectoryInfo(value);
            }
            else if (Directory.Exists(Path.Combine(maindirectory.FullName, value)))
            {
                maindirectory = new DirectoryInfo(Path.Combine(maindirectory.FullName, value));
            }
            return "ok";
        }
        static string Exit()
        {
            Environment.Exit(0);
            return "ok";
        }
        static void MainProgramm()
        {
            while (true)
            {
                DisplayPrompt(maindirectory);
                ProcessAnswer(Console.ReadLine().Split(' '));
            }
        }
        static void Main(string[] args)
        {
            maindirectory = new DirectoryInfo(@"C:\Users");
            keyaction = new Dictionary<string, Func<string>>
            {
                {"lf", ListFiles},
                {"ld", ListDirectories},
                {"cd", ChangeDirectory},
                {"exit", Exit}
            };
            Console.Clear();
            MainProgramm();
        }
    }
