public PerformanceCounter privateBytes;
public PerformanceCounter gen2Collections;
public Form1()
{
    InitializeComponent();
    var currentProcess = Process.GetCurrentProcess().ProcessName;
    privateBytes =  new PerformanceCounter(categoryName: "Process", counterName: "Private Bytes", instanceName: currentProcess);
    gen2Collections = new PerformanceCounter(categoryName: ".NET CLR Memory", counterName: "# Gen 2 Collections", instanceName: currentProcess);
}
async Task LongRunningProcess()
{
    await Task.Delay(500);
}
private async void button1_Click(object sender, EventArgs e)
{
    for (int i = 0; i <100; i++)
    {
        progressBar1.Value = i;
        textBox1.Text = "privateBytes:" + privateBytes.NextValue().ToString() + " gen2Collections:" + gen2Collections.NextValue().ToString() ;
        await Task.Run(() => LongRunningProcess());
    }
    
}
<br>
*Note: Also Check Hans Passant's answer on [ISupportInitialize][1]*
  [1]: https://stackoverflow.com/a/30464280/4686729
