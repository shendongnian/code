    void button1_Click(object sender, EventArgs e)
    {
        var notepad = Process.GetProcessesByName("notepad").FirstOrDefault();
        if (notepad != null)
        {
            var edit = FindWindowEx(notepad.MainWindowHandle, IntPtr.Zero, "Edit", null);
            PerformRightClick(edit, new Point(20, 20));
        }
    }
