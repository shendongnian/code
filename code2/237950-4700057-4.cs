    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    
    class MainUIThreadForm : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainUIThreadForm());
        }
    
        SecondUIThreadForm secondThreadForm;
        public MainUIThreadForm()
        {
            Text = "First UI";
            Button button;
            Controls.Add(button = new Button { Text = "Start second UI thread", AutoSize = true, Location = new Point(10, 10) });
            button.Click += (s, e) =>
                {
                    if (secondThreadForm == null || !secondThreadForm.IsHandleCreated)
                        secondThreadForm = SecondUIThreadForm.Create();
                };
            Controls.Add(button = new Button { Text = "Stop second UI thread", AutoSize = true, Location = new Point(10, 40) });
            button.Click += (s, e) =>
            {
                if (secondThreadForm != null && secondThreadForm.IsHandleCreated)
                    secondThreadForm.Invoke((Action)(() => secondThreadForm.Close()));
            };
        }
    }
    
