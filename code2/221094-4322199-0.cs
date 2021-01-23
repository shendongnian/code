    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            using (var form = new Form {
                Controls = {
                    new PropertyGrid { Dock = DockStyle.Fill,
                        SelectedObject = new Test {
                            Foo = "one element without category",
                            Bar = "several categories",
                            Blip = "with elements",
                            Blap = "inside",
                            Blop = "below"
                        }}}}) {
                Application.Run(form);
            }
        }
    }
    class Test {
        [Category(" ")] public string Foo { get; set; }
        [Category("x")] public string Bar{ get; set; }
        [Category("x")] public string Blip { get; set; }
        [Category("y")] public string Blap { get; set; }
        [Category("y")] public string Blop { get; set; }
    }
