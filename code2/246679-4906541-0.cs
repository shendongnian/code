    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    static class Program
    {
        class Foo
        {
            public int A { get; set; }
            public string B { get; set; }
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var form = new Form())
            using (var grid = new DataGridView { Dock = DockStyle.Fill })
            using (var add = new Button { Dock = DockStyle.Bottom, Text = "add" })
            using (var remove = new Button { Dock = DockStyle.Top, Text = "remove" })
            {
                form.Controls.Add(grid);
                form.Controls.Add(add);
                form.Controls.Add(remove);
                var lst = new BindingList<Foo>();
                var rnd = new Random();
                add.Click += delegate
                {
                    lst.Add(new Foo { A = rnd.Next(1, 6), B = "new" });
                };
                remove.Click += delegate
                {
                    int index = 0;
                    foreach (var row in lst)
                    { // just to illustrate removing a row by predicate
                        if (row.A == 2) { lst.RemoveAt(index); break; }
                        index++;
                    }
                };
                grid.DataSource = lst;
                Application.Run(form);
            }
        }
    }
