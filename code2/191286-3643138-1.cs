    using System;
    using System.Windows.Forms;
    public sealed partial class MainForm : Form
    {
        private readonly Button startButton;
        private readonly Button errorButton;
        private readonly Button cancelButton;
        private readonly ProgressBar progressBar;
        public MainForm()
        {
            this.startButton = new Button
            {
                Text = "Start",
                Height = 23,
                Width = 75,
                Left = 12,
                Top = 12,
            };
            this.errorButton = new Button
            {
                Text = "Error",
                Height = 23,
                Width = 75,
                Left = this.startButton.Right + 6,
                Top = 12,
            };
            this.cancelButton = new Button
            {
                Text = "Cancel",
                Enabled = false,
                Height = 23,
                Width = 75,
                Left = this.errorButton.Right + 6,
                Top = 12,
            };
            this.progressBar = new ProgressBar
            {
                Width = this.cancelButton.Right - 12,
                Height = 23,
                Left = 12,
                Top = this.startButton.Bottom + 6,
            };
            this.startButton.Click +=
              (sender, e) => this.startButton_Click(sender, e);
            this.errorButton.Click +=
              (sender, e) => this.errorButton_Click(sender, e);
            this.cancelButton.Click +=
              (sender, e) => this.cancelButton_Click(sender, e);
            this.Controls.AddRange(new Control[] 
        { 
          this.startButton, 
          this.errorButton, 
          this.cancelButton, 
          this.progressBar, 
        });
        }
        partial void startButton_Click(object sender, EventArgs e);
        partial void errorButton_Click(object sender, EventArgs e);
        partial void cancelButton_Click(object sender, EventArgs e);
        private void TaskIsRunning()
        {
            // Update UI to reflect background task. 
            this.startButton.Enabled = false;
            this.errorButton.Enabled = false;
            this.cancelButton.Enabled = true;
        }
        private void TaskIsComplete()
        {
            // Reset UI. 
            this.progressBar.Value = 0;
            this.startButton.Enabled = true;
            this.errorButton.Enabled = true;
            this.cancelButton.Enabled = false;
        }
    }
    class Program
    {
        [STAThread]
        static void Main()
        {
            // Run the UI. 
            Application.Run(new MainForm());
        }
    }
