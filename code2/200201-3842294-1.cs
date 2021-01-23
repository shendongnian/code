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
            var dgv = new CustomDataGridView { Dock = DockStyle.Fill };
            dgv.Columns.Add(new DataGridViewComboBoxColumn
            {
                HeaderText = "Header",
                DataSource = new string[] { "One", "Two", "Three", "Four" },
            });
            dgv.CommandKeyPress += new CommandKeyPressHandler(dgv_CommandKeyPress);
    
            Controls.Add(dgv);
            Controls.Add(new Button { Text = "Place holder", Dock = DockStyle.Top });
        }
    
        bool dgv_CommandKeyPress(object sender, Keys keyData)
        {
            if ((keyData & (Keys.Alt | Keys.C)) == (Keys.Alt | Keys.C))
            {
                new Form { Text = "Form2" }.Show(this);
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
