    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WinForm
    {
      public partial class Form1 : Form
      {
        readonly CancellationTokenSource _cts = new CancellationTokenSource();
        public Form1()
        {
          InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
          var task = Task.Factory.StartNew(() => DoSomething());
          Task updatingLabel = Task.Factory.StartNew(() => UpdateLabelValidated(_cts));
          task.ContinueWith(_=> _cts.Cancel());
        }
        private void DoSomething()
        {
          Thread.Sleep(20000);
        }
        private void UpdateLabelValidated(CancellationTokenSource token)
        {
          while (!token.IsCancellationRequested)
          {
            UpdateLabel();
            Thread.Sleep(500);
          }
        }
        private void UpdateLabel()
        {
          if (this.InvokeRequired)
          {
            this.BeginInvoke(new Action(UpdateLabel), new object[] { });
          }
          else
          {
            label1.Text += ".";
            if (label1.Text.Length > 5)
              label1.Text = ".";
          }
        }
      }
    }
