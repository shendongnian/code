    // example key combo from user input
    var ksc = "Alt+Shift+M";
    ksc = ksc.ToLower();
    KeyBinding kb = new KeyBinding();
    if (ksc.Contains("alt"))
        kb.Modifiers = ModifierKeys.Alt;
    if (ksc.Contains("shift"))
        kb.Modifiers |= ModifierKeys.Shift;
    if (ksc.Contains("ctrl") || ksc.Contains("ctl"))
        kb.Modifiers |= ModifierKeys.Control;
    string key =
        ksc.Replace("+", "")
            .Replace("-", "")
            .Replace("_", "")
            .Replace(" ", "")
            .Replace("alt", "")
            .Replace("shift", "")
            .Replace("ctrl", "")
            .Replace("ctl", "");
    key =   CultureInfo.CurrentCulture.TextInfo.ToTitleCase(key);
    if (!string.IsNullOrEmpty(key))
    {
        KeyConverter k = new KeyConverter();
        kb.Key = (Key)k.ConvertFromString(key);
    }
    // Whatever command you need to bind to
    // CommandBase here is a custom class I use to create commands
    // with Execute/CanExecute handlers
    kb.Command = new CommandBase((s, e) => InsertSnippet(snippet),
                                 (s,e) => Model.IsEditorActive);
    Model.Window.InputBindings.Add(kb);
