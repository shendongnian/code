    // Property:
    private bool? _console_present;
    public bool console_present {
        get {
            if (_console_present == null) {
                _console_present = true;
                try { int window_height = Console.WindowHeight; }
                catch { _console_present = false; }
            }
            return _console_present.Value;
        }
    }
    //Usage
    if (console_present)
        Console.Read();
