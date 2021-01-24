    public static void Main()
    {
        string nspace = "System.Text";
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in assembly.GetTypes().Where(t => t.IsClass && t.Namespace == nspace))
            {
                Console.WriteLine(type.FullName);
            }
        }
    }
