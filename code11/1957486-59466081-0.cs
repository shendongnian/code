    [DllImport("kernel32.dll")]
    public static extern IntPtr _lopen(string lpPathName, int iReadWrite);
    [DllImport("kernel32.dll")]
    public static extern bool CloseHandle(IntPtr hObject);
    public const int OF_READWRITE = 2;
    public const int OF_SHARE_DENY_NONE = 0x40;
    public readonly IntPtr HFILE_ERROR = new IntPtr(-1);
    private void button1_Click(object sender, EventArgs e)
    {
        string vFileName = textBox1.Text;
        if (!File.Exists(vFileName))
        {
            MessageBox.Show("Not Exist!");
            return;
        }
        IntPtr vHandle = _lopen(vFileName, OF_READWRITE | OF_SHARE_DENY_NONE);
        if (vHandle == HFILE_ERROR)
        {
            MessageBox.Show("Occupied！");
            return;
        }
        CloseHandle(vHandle);
        MessageBox.Show("Not Occupied！");
    }
