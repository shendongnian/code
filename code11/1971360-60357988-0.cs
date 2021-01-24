    public static string[] GetPathOf(string cmd)
        {
            var list = new List<string>();
            list.AddRange(Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Machine).Split(';'));
            list.AddRange(Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.Process).Split(';'));
            list.AddRange(Environment.GetEnvironmentVariable("path", EnvironmentVariableTarget.User).Split(';'));
            list = list.Distinct().Where(e=>Directory.Exists(e)).SelectMany(e=> new DirectoryInfo(e).GetFiles()).Where(e=>Regex.IsMatch(e.Name,"(?i)^"+cmd+"\\.(?:exe|cmd|com)")).Select(e=>e.FullName).ToList();
            return list.ToArray();
        }
