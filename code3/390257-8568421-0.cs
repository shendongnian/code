    public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
			backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
		}
		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			progressBar1.MarqueeAnimationSpeed = 0;
		}
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			DoSomething();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			progressBar1.MarqueeAnimationSpeed = 100;
			backgroundWorker1.RunWorkerAsync();
		}
		private void DoSomething()
		{
			Thread.Sleep(2000);
		}
	}
