    static class Program
    {
        [STAThread]
        static void Main()
        {
            Button btn;
            var data = new SortableBindingList<Foo> { new Foo { Bar = "abc" } };
            using (var form = new Form
            {
                Controls = {
                    (btn = new Button { Dock = DockStyle.Bottom, Text = "add"}),
                    new DataGridView { Dock = DockStyle.Fill, DataSource = data,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells }
                }
            })
            {
                btn.Click += delegate { data.Add(new Foo { Bar = DateTime.Now.Ticks.ToString()}); };
                Application.Run(form);
            }
        }
    }
    class Foo
    {
        public string Bar { get; set; }
    }
