    [DllImport("MyDll.dll")]
    private static extern string GetSomeText();
    public static string GetAllValidProjects()
    {
        string s = new string(GetSomeText());
        return s;
    }
