    private void tsmiExit_Click(object sender, EventArgs e)
    {
        // close the application forefully
        TerminateApplication();
    }
    /// <summary>
    /// Closes the Application.
    /// </summary>
    private void TerminateApplication()
    {
        // need to forcefully dispose of notification icon
        this.notifyIcon1.Dispose();
        // and exit the application
        Application.Exit();
    }
