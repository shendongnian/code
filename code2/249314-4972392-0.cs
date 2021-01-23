    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class FormBase : Form
    {
        public FormBase()
        {
            Panel panel;
            Controls.Add(panel = new Panel { Dock = DockStyle.Bottom, Height = 120, BackColor = Color.LightGray });
            panel.Controls.Add(new Button { Text = "Button 1", Anchor = AnchorStyles.Bottom | AnchorStyles.Right, Location = new Point(panel.ClientSize.Width - 80, panel.ClientSize.Height - 60) });
            panel.Controls.Add(new Button { Text = "Button 2", Anchor = AnchorStyles.Bottom | AnchorStyles.Right, Location = new Point(panel.ClientSize.Width - 80, panel.ClientSize.Height - 30) });
        }
    }
    
    class FormInherited : FormBase
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormInherited());
        }
    }
