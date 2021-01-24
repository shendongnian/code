    public static event KeyEventHandler ChangeDetected; // handler with derived args signature
    private static void Program_ChangeDetected(object sender, EventArgs e) // base event args are OK
    {
        Console.WriteLine("ChangeDetected");
    }
    static void Main(string[] args)
    {
        ChangeDetected += Program_ChangeDetected;
        ChangeDetected?.Invoke(null, new KeyEventArgs(default)); // base event args are NOT OK
    }
