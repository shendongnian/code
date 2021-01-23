    static class Program
    {
        private static Form form;
        private static int i;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                VirtualMode = true,
                AllowUserToAddRows = false,
                Columns =
                {
                    new DataGridViewTextBoxColumn { HeaderText = "foo" },
                    new DataGridViewTextBoxColumn { HeaderText = "bar" },
                },
            };
            grid.CellValueNeeded += OnCellValueNeeded;
            form = new Form
            {
                Controls = { grid }
            };
            
            //grid.RowCount = 0;
            grid.RowCount = 10000;
            Application.Run(form);
        }
        private static void OnCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            i++;
            form.Text = i.ToString();
            e.Value = "fooValue";
        }
    }
