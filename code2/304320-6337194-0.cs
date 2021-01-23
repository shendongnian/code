    int i = 0;
    foreach (Process pro in Process.GetProcesses())
    {
        if (pro.ProcessName.StartsWith("notepad", Stringcomparison.CurrentCultureIgnoreCase))
        {
            i++;
            textBox1.Text = Convert.ToString(i);
        }
    }
