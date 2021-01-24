void BtnRunClick(object sender, EventArgs e)
{
	new Thread(Run).Start();
}
void Run()
{
	int nlines = 0;
	while (nlines < 50)
	{
		nlines = listBox1.Items.Count;
		ReadLinesFromFile();
		Thread.Sleep(1000);
	}
}
void ReadLinesFromFile()
{
	string sFile = @"D:\Temp1\testfile.txt";
	string[] lines = File.ReadAllLines(sFile);
	
	listBox1.InvokeOnUIThread(() => {
		listBox1.Items.Clear();
		foreach (string line in lines)
		{
			listBox1.Items.Add(line);
			listBox1.SelectedIndex = listBox1.Items.Count - 1;
		}
	});
}
Add this class to your project:
public static class ControlExtensions
{
    public static void InvokeOnUIThread(this Control control, Action action)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(action);
        }
        else
        {
            action();
        }
    }
}
