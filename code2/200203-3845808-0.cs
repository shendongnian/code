    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        DataGridView dgv;
    
        public Form1()
        {
            Text = "Form1";
            dgv = new DataGridView { Dock = DockStyle.Fill };
            dgv.Columns.Add(new DataGridViewComboBoxColumn
            {
                HeaderText = "Header",
                DataSource = new string[] { "One", "Two", "Three", "Four" },
            });
    
            Controls.Add(dgv);
            Controls.Add(new Button { Text = "Place holder", Dock = DockStyle.Top });
        }
    
        [DllImport("user32.dll")]
        private static extern bool IsChild(IntPtr hwndParent, IntPtr hwndChild);
    
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData & (Keys.Alt | Keys.C)) == (Keys.Alt | Keys.C))
            {
                if (dgv.Handle == msg.HWnd || IsChild(dgv.Handle, msg.HWnd))
                {
                    new Form { Text = "Form2" }.Show(this);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
