    private void Form1_Load(object sender, EventArgs e)
    {
        var arguments = Environment.GetCommandLineArgs();
        if (arguments.Length > 1) {
            MessageBox.Show(arguments[1]);
        }
    }
