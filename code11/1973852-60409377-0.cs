    using System;
    using System.Threading;
    using Gtk;
    public partial class MainWindow : Gtk.Window
    {
    private Gtk.TreeView treeview1;
    private int guiThreadId;
    private bool stop = false;
    private int threadId = 0;
    public delegate void ThreadStart();
    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
        guiThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
        // Create our TreeView
        treeview1 = new Gtk.TreeView();
        Gtk.ScrolledWindow scrolledWindow = new ScrolledWindow();
        scrolledWindow.Add(treeview1);
        Gtk.VBox vBox = new VBox();
        vBox.Add(scrolledWindow);
        this.Add(vBox);
        CellRendererCombo cellRendererCombo = new CellRendererCombo();
        Gtk.TreeViewColumn treeViewColumn = new TreeViewColumn();
        treeViewColumn.Title = "TYPE";
        treeViewColumn.PackStart(cellRendererCombo, false);
        treeViewColumn.AddAttribute(cellRendererCombo, "text", 0);
        cellRendererCombo.Editable = true;
        cellRendererCombo.Model = new Gtk.ListStore(typeof(string));
        cellRendererCombo.Mode = CellRendererMode.Editable;
        cellRendererCombo.TextColumn = 0;
        cellRendererCombo.HasEntry = false;
        cellRendererCombo.WidthChars = 20;
        cellRendererCombo.Style = Pango.Style.Normal;
        cellRendererCombo.Edited += OnActionChanged;
        cellRendererCombo.EditingStarted += CellEditingStartedHandler;
        treeview1.AppendColumn(treeViewColumn);
        Gtk.ListStore listStore = new ListStore(typeof(string));
        listStore.AppendValues("A");
        listStore.AppendValues("B");
    }
    protected void OnEdited(object sender, Gtk.EditedArgs args)
    {
        Gtk.TreeSelection selection = treeview1.Selection;
        Gtk.TreeIter iter;
        selection.GetSelected(out iter);
        treeview1.Model.SetValue(iter, 1, args.NewText); // the CellRendererText
    }
    protected void CellEditingStartedHandler(object o, EditingStartedArgs args)
    {
        Console.WriteLine($"CellEditingStartedHandler");
        if (o is Gtk.CellRendererCombo)
        {
            Gtk.CellRendererCombo cellRendererCombo = (Gtk.CellRendererCombo)o;
            ((Gtk.ListStore)cellRendererCombo.Model).Clear();
            ((Gtk.ListStore)cellRendererCombo.Model).AppendValues("A");
            ((Gtk.ListStore)cellRendererCombo.Model).AppendValues("B");
        }
    }
    }
