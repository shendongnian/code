    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    
    public class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        BindingSource source;
    
        public Form1()
        {
            Controls.Add(new DataGridView { Name = "DGV", Dock = DockStyle.Fill, TabIndex = 2 });
            Controls.Add(new TextBox { Name = "Find", Dock = DockStyle.Top, TabIndex = 1 });
    
            DataTable table = CreateData();
            source = new BindingSource(table, null);
            (Controls["DGV"] as DataGridView).DataSource = source;
            source.Sort = "First";
    
            Controls["Find"].TextChanged += (s, e) =>
                {
                    int index = source.Find("First", (s as Control).Text);
                    if (index >= 0)
                        source.Position = index;
                };
        }
    
        private DataTable CreateData()
        {
            DataTable table = new DataTable { Columns = { "First", "Second" } };
            foreach (var o in Enumerable.Range('a', 26).Select(ch => new { F = new String((char)ch, 1), S = new String((char)('z' - (ch - 'a')), 1)}))
            {
                DataRow dr = table.NewRow();
                dr[0] = o.F;
                dr[1] = o.S;
                table.Rows.Add(dr);
            };
            return table;
        }
    }
