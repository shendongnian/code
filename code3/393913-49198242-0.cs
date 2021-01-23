    private void Window_Drop(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            dynamic shortcut;
            dynamic windowsShell;
            try
            {
                var file = files[0];
                if (Path.GetExtension(file)?.Equals(".lnk",StringComparison.OrdinalIgnoreCase) == true)
                {
                    Type shellObjectType = Type.GetTypeFromProgID("WScript.Shell");
                    windowsShell = Activator.CreateInstance(shellObjectType);
                    shortcut = windowsShell.CreateShortcut(file);
                    file = shortcut.TargetPath;
                    // Release the COM objects
                    shortcut = null;
                    windowsShell = null;
                }
                //
                // <use file>...
                //
            }
            finally
            {
                // Release the COM objects
                shortcut = null;
                windowsShell = null;
            }
        }
    }
