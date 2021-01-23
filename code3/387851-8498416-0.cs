        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var main = new Form1();
            main.Load += delegate { main.SetDesktopBounds(100, 100, 300, 300);  };
            Application.Run(main);
        }
