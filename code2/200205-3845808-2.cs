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
    
            dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            DataGridViewComboBoxColumn dgvColumn = new DataGridViewComboBoxColumn();
            dgvColumn.HeaderText = "Header";
            dgvColumn.DataSource = new string[] { "One", "Two", "Three", "Four" };
            dgv.Columns.Add(dgvColumn);
            Controls.Add(dgv);
    
            Button button = new Button();
            button.Text = "Place holder";
            button.Dock = DockStyle.Top;
            Controls.Add(button);
        }
    
        [DllImport("user32.dll")]
        private static extern bool IsChild(IntPtr hwndParent, IntPtr hwndChild);
    
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData & (Keys.Alt | Keys.C)) == (Keys.Alt | Keys.C))
            {
                if (dgv.Handle == msg.HWnd || IsChild(dgv.Handle, msg.HWnd))
                {
                    Form form = new Form();
                    form.Text = "Form2";
                    form.Show(this);
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
