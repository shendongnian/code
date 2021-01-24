static void ShowPath(string progName)
{
    var extensions = new List<string> { ".com", ".exe" };
    string envPath = Environment.GetEnvironmentVariable("Path");
    var dirs = envPath.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string d in dirs.Where(f => Directory.Exists(f)))
    {
        foreach (var f in (Directory.EnumerateFiles(d).
            Where(thisFile => extensions.Any(h => Path.GetExtension(thisFile).Equals(h, StringComparison.InvariantCultureIgnoreCase)))))
        {
            if (Path.GetFileNameWithoutExtension(f).Equals(progName, StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine(f);
                return;
            }
        }
    }
    Console.WriteLine("Not found.");
}
static void Main(string[] args)
{
    ShowPath("calc");
    Console.ReadLine();
}
Output:
> C:\WINDOWS\system32\calc.exe
There is always the possibility that the current user does not have permission to list the files from somewhere in the path, so checks should be added for that. Also, you might want to use `StringComparison.CurrentCultureIgnoreCase` for the comparison.
