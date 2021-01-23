    public static void Main()
    {
        using (var hotkeyManager = new GlobalHotkeyManager())
        {
            var hotkey = new Hotkey(KeyModifier.Ctrl | KeyModifier.Alt, Key.S);
            hotkeyManager.Add(hotkey, () => System.Console.WriteLine(hotkey));
            System.Console.ReadKey();
        }
    }
