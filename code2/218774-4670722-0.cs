    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public class MainAppForm : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainAppForm());
        }
        public MainAppForm()
        {
            Text = "MainAppForm";
            Controls.Add(new Button { Text = "Show ModalDialog", AutoSize = true, Location = new Point(10, 10) });
            Controls[0].Click += (s, e) =>
                {
                    using (ModalDialog dlg = new ModalDialog())
                        dlg.ShowDialog(this);
                };
        }
    }
    
    public class ModalDialog : Form
    {
        public ModalDialog()
        {
            Text = "ModalDialog";
            Controls.Add(new Button { Text = "Show FontDialog", AutoSize = true, Location = new Point(10, 10) });
            Controls[0].Click += (s, e) =>
            {
                using (FontDialog dlg = new FontDialog())
                    dlg.ShowDialog(this);
            };
        }
    }
