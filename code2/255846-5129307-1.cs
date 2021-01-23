    using System;
    using System.Windows.Forms;
    
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
    
            var G1 = new ListViewGroup("Group 1");
            var G2 = new ListViewGroup("Group 2");
    
            Application.Run(new Form {
                Controls = {
                    new ListView  {
                        Dock = DockStyle.Fill,
                        Groups = { G1, G2 },
                        View = View.Details,
                        //Columns = { "First", "Second" },
                        Items = {
                            new ListViewItem { Text = "One", Group = G1, SubItems = { "1" } },
                            new ListViewItem { Text = "Two", Group = G2, SubItems = { "2" } },
                            new ListViewItem { Text = "Three", Group = G2, SubItems = { "3" } },
                        },
                    },
                },
            });
        }
    }
