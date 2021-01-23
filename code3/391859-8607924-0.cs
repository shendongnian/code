    using (DdeClient client = new DdeClient("MSAccess", Path.GetFileName(theAccessApp))) {
        if (!TryConnect(client)) {
            Process.Start(theAccessApp);
            Thread.Sleep(2000);
            if (!TryConnect(client)) {
                Messagebox.Show("Could not start: " + theAccessApp);
                return;
            }
        }
        // Close the form if open
        client.Execute("[Close 2, \"MyForm\"]", 10000);
    
        // Open the form
        string openCmd = String.Format("[OpenForm \"MyForm\",,,,,,\"{0}\"]", anyOpenArgsParam);
        client.Execute(openCmd, 10000);
    }
