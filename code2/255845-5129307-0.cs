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
            var G1 = new ListViewGroup("Group 1");
            var G2 = new ListViewGroup("Group 2");
            Controls.Add(new ListView
            {
                Dock = DockStyle.Fill,
                Groups = { G1, G2 },
                View = View.Details,
                //Columns = { "First", "Second" },
                Items =
                {
                    new ListViewItem { Text = "One", Group = G1, SubItems = { "1" } },
                    new ListViewItem { Text = "Two", Group = G2, SubItems = { "2" } },
                    new ListViewItem { Text = "Three", Group = G2, SubItems = { "3" } },
                    new ListViewItem { Text = "Four", Group = G1, SubItems = { "4" } },
                    new ListViewItem { Text = "Five", Group = G1, SubItems = { "5" } },
                    new ListViewItem { Text = "Six", Group = G1, SubItems = { "6" } },
                },
            });
        }
    }
