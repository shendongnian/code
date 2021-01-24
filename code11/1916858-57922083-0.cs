    public class MainWindow: Gtk.Window {
        public MainWindow(): base(Gtk.WindowType.Toplevel) 
        {
            this.Build();
            this.AppendValues( true, "world", "gtk" );
            this.AppendValues( false, "you", "ebay" );
        }
        void Build()
        {
            this.BuildTreeview();
            this.DeleteEvent += (o, args) => this.Close();
            this.ShowAll();
        }
        void Close()
        {
            Gtk.Application.Quit();
        }
        void BuildTreeview()
        {
            this.TreeView = new Gtk.TreeView();
            var store = new Gtk.TreeStore( typeof( bool ), typeof( string ), typeof( string ) );
            this.TreeView.Model = store;
            // Create a column
            var column1 = new Gtk.TreeViewColumn();
            // Add a toggle render
            var toggleRenderer = new Gtk.CellRendererToggle();
            column1.PackStart( toggleRenderer, true );
            column1.AddAttribute( toggleRenderer, "active", 0 );
            column1.Title = "Column 1";
            // And add a text renderer to the same column
            var textRenderer1 = new Gtk.CellRendererText();
            column1.PackStart( textRenderer1, true );
            column1.AddAttribute( textRenderer1, "text", 1 );
            // Now add a plain text column
            var column2 = new Gtk.TreeViewColumn();
            var textRenderer2 = new Gtk.CellRendererText();
            column2.PackStart( textRenderer2, true );
            column2.AddAttribute( textRenderer2, "text", 2 );
            column2.Title = "Column 2";
            this.TreeView.AppendColumn( column1 );
            this.TreeView.AppendColumn( column2 );
            this.Add( this.TreeView );
        }
        public void AppendValues(params object[] values)
        {
            var store = (Gtk.TreeStore) this.TreeView.Model;
            store.AppendValues( values );
        }
        public Gtk.TreeView TreeView {
            get; private set;
        }
    }
