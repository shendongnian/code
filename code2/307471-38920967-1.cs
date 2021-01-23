    public bool console_present {
        get {
            try { return Console.WindowHeight > 0; }
            catch { return false; }
        }
    }
    //Usage
    if (console_present) { Console.Read(); }
