    private Timer check;
    
    public MyForm()
    {
    InitializeCheck();
    }
    private void InitializeCheck()
    {
    check = new Timer();
    check.Interval = 5000;
    check.Tick += Check_Tick;
    check.Enabled = false;
    }
    private void Check_Tick(object sender, EventArgs e)
    {
    CheckProgram();
    }
    private void CheckProgram()
    {
    Process[] program = rocess.GetProcessesByName("notepad");
    if (program.Length == 0)
    {
    check.Enabled = false;
    TopMost = true;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
    TopMost = false;
    check.Enabled = true;
    }
