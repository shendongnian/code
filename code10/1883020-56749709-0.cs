    class MainWindow: Gtk.Window {
        public MainWindow()
            :base(Gtk.WindowType.Toplevel)
        {
            this.Build();
            this.DeleteEvent += (o, args) => Gtk.Application.Quit();
        }
        void Build()
        {
            var imgContainer = this.BuildEmbeddedImage();
            this.Add( imgContainer );
        }
        Gtk.Image BuildExternalImage()
        {
            return new Gtk.Image( "res/prowl.jpg" );
        }
        Gtk.Image BuildEmbeddedImage()
        {
            var pixbufImage = new Gdk.Pixbuf(
                System.Reflection.Assembly.GetEntryAssembly(),
                "CSShowImage.res.prowl.jpg");
            return new Gtk.Image( pixbufImage );
        }
    }
    class Ppal
    {
        [System.STAThread]
        static void Main()
        {
            Gtk.Application.Init();
            new MainWindow().ShowAll();
            Gtk.Application.Run();
        }
    }
