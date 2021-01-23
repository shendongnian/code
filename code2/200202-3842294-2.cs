    using System;
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
    
        public Form1()
        {
            Text = "Form1";
    
            CustomDataGridView dgv = new CustomDataGridView();
            dgv.Dock = DockStyle.Fill;
            DataGridViewComboBoxColumn dgvColumn = new DataGridViewComboBoxColumn();
            dgvColumn.HeaderText = "Header";
            dgvColumn.DataSource = new string[] { "One", "Two", "Three", "Four" };
            dgv.Columns.Add(dgvColumn);
            dgv.CommandKeyPress += new CommandKeyPressHandler(dgv_CommandKeyPress);
            Controls.Add(dgv);
    
            Button button = new Button();
            button.Text = "Place holder";
            button.Dock = DockStyle.Top;
            Controls.Add(button);
        }
    
        bool dgv_CommandKeyPress(object sender, Keys keyData)
        {
            if ((keyData & (Keys.Alt | Keys.C)) == (Keys.Alt | Keys.C))
            {
                Form form = new Form();
                form.Text = "Form2";
                form.Show(this); 
                return true;
            }
            return false;
        }
    }
    
    delegate bool CommandKeyPressHandler(object sender, Keys keyData);
    
    class CustomDataGridView : DataGridView
    {
        public event CommandKeyPressHandler CommandKeyPress;
    
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            CommandKeyPressHandler eventDelegate = CommandKeyPress;
            if (eventDelegate != null)
            {
                foreach (CommandKeyPressHandler handler in eventDelegate.GetInvocationList())
                {
                    if (handler(this, keyData))
                        return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
