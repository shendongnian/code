    Console.WriteLine("Searching file in...");
    // save the current cursor position
    var cursorLeft = Console.CursorLeft;
    var cursorTop = Console.CursorTop;
    // build a format string to establish the maximum width do display
    var maxWidth = 60;
    var fmt = String.Format("{{0,-{0}}}", maxWidth);
    foreach (var dir in dirList)
    {
        // restore the cursor position
        Console.SetCursorPosition(cursorLeft, cursorTop);
        // trim the name if necessary
        var name = Path.GetFileName(dir);
        if (name.Length > maxWidth)
            name = name.Substring(0, maxWidth);
        // write the trimmed name
        Console.Write(fmt, name);
        // do some work
    }
    Console.WriteLine(); // end the previous line
