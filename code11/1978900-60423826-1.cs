    namespace WpfApp1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var z = new Container {Text = "z"};
                var a = new Container {Text = "a"};
                var b = new Container {Text = "b"};
                var c = new Container {Text = "c"};
                var d = new Container {Text = "d"};
                var e = new Container {Text = "e"};
                var f = new Container {Text = "f"};
                var g = new Container {Text = "g"};
                var h = new Container {Text = "h"};
    
                z.Root.Add(a);
                a.Root.Add(b);
                b.Soft.Add(c);
                c.Hard.Add(d);
                d.Root.Add(e);
                d.Root.Add(f);
                f.Soft.Add(g);
                f.Hard.Add(h);
    
                DataContext = z;
            }
        }
    }
