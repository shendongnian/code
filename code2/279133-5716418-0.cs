    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    namespace WindowsFormsApplication
    {
        public partial class FormMain : Form
        {
            public FormMain()
            {
                InitializeComponent();
            }
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                RestartTimer();
            }
            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                var textToAnalyze = textBox1.Text;
                if (e.Cancel)
                {
                    // ToDo: if we have a more complex algorithm check this
                    //       variable regulary to abort your count algorithm.
                }
                var words = textToAnalyze.Split();
                e.Result = words.Length;
            }
            private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Cancelled
                  || e.Error != null)
                {
                    // ToDo: Something bad happened and no results are available.
                }
                var count = e.Result as int?;
                if (count != null)
                {
                    var message = String.Format("We found {0} words in the text.", count.Value);
                    MessageBox.Show(message);
                }
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                if (backgroundWorker1.IsBusy)
                {
                    // ToDo: If we already run, should we let it run or restart it?
                    return;
                }
                timer1.Stop();
                backgroundWorker1.RunWorkerAsync();
            }
            private void RestartTimer()
            {
                if (backgroundWorker1.IsBusy)
                {
                    // If BackgroundWorker should stop it's counting
                    backgroundWorker1.CancelAsync();
                }
                timer1.Stop();
                timer1.Start();
            }
        }
    }
