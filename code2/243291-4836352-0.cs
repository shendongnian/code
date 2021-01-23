    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    class Foo
    {
        public int Value { get; set; }
        public Foo(int value) { Value = value; }
        public override string ToString() { return Value.ToString(); }
    }
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            using(var form = new Form())
            using (var lst = new ListBox())
            using (var timer = new Timer())
            {
                var data = new BindingList<Foo>();
                form.Controls.Add(lst);
                lst.DataSource = data;
                timer.Interval = 1000;
                int i = 0;
                timer.Tick += delegate
                {
                    data.Add(new Foo(i++));
                };
                lst.Dock = DockStyle.Fill;
                form.Shown += delegate
                {
                    timer.Start();
                };
                Application.Run(form);
            }
        }
    }
