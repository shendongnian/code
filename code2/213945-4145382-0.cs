    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    class Foo {
        private readonly List<Bar> bars = new List<Bar>();
        public List<Bar> Bars { get { return bars; } }
        public string Caption { get; set; }
    }
    class Bar {
        public string Name { get;set; }
        public int Id { get; set; }
    }
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new Form {
                Controls = { new PropertyGrid { Dock = DockStyle.Fill,
                                                SelectedObject = new Foo()
            }}});
        }
    }
