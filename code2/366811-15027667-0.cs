    class MainClass
    {
	public static void Main (string[] args)
	{
            Application.Init ();
            var win = CreateTreeWindow();
            win.ShowAll ();
            Application.Run ();
        }
        public static Gtk.Window CreateTreeWindow()
        {
            Gtk.Window window = new Gtk.Window("Sortable TreeView");
            Gtk.TreeIter iter;
            Gtk.TreeViewColumn col;
            Gtk.CellRendererText cell;
            Gtk.TreeView tree = new Gtk.TreeView();
            cell = new Gtk.CellRendererText();
            col = new Gtk.TreeViewColumn();
            col.Title = "Column 1";            
            col.PackStart(cell, true);
            col.AddAttribute(cell, "text", 0);
            col.SortColumnId = 0;
            tree.AppendColumn(col);
            cell = new Gtk.CellRendererText();
            col = new Gtk.TreeViewColumn();
            col.Title = "Column 2";            
            col.PackStart(cell, true);
            col.AddAttribute(cell, "text", 1);
            tree.AppendColumn(col);
            Gtk.TreeStore store = new Gtk.TreeStore(typeof (string), typeof (string));
            iter = store.AppendValues("BBB");
            store.AppendValues(iter, "AAA", "Zzz");
            store.AppendValues(iter, "DDD", "Ttt");
            store.AppendValues(iter, "CCC", "Ggg");
            iter = store.AppendValues("AAA");
            store.AppendValues(iter, "ZZZ", "Zzz");
            store.AppendValues(iter, "GGG", "Ggg");
            store.AppendValues(iter, "TTT", "Ttt");
            Gtk.TreeModelSort sortable = new Gtk.TreeModelSort(store);
            sortable.SetSortFunc(0, delegate(TreeModel model, TreeIter a, TreeIter b) {
                string s1 = (string)model.GetValue(a, 0);
                string s2 = (string)model.GetValue(b, 0);
                return String.Compare(s1, s2);
            });
            tree.Model = sortable;
            window.Add(tree);
            return window;
        }
    }
