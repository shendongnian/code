    private List<Process> children = new List<Process>();
    private void button1_Click(object sender, EventArgs e)
    {
        Process p = new Process();
        p.StartInfo.FileName = Application.ExecutablePath;
        p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
        p.Start();
        children.Add(p);
    }
    private Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        foreach (Process p in this.children)
        {
            // posts WM_CLOSE to the main handle of the process
            // which allows a graceful exit, as if the user clicked [X]
            p.CloseMainWindow();
            // p.Kill(); // less graceful, just kill
        }
    }
