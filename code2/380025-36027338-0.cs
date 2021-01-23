    class CellRendererSimple : CellRenderer
{
    //property asigned to by treeviewcolumn
    //eg. TreeViewColumn tvc = new TreeViewColumn("Column 0", new CellRendererMenu(),"text",0);
    [GLib.Property("text")] //this line seems to be nessasary for the property to be recognised by the treeviewcolumn.
    public string text
    {
        get;
        set;
    }
    protected override void Render(Gdk.Drawable window, Widget widget, Gdk.Rectangle background_area, Gdk.Rectangle cell_area, Gdk.Rectangle expose_area, CellRendererState flags)
    {
        //this seems to be the minimum to render text
        GC gc = widget.Style.TextGC(StateType.Normal);
        Pango.Layout layout = new Pango.Layout(widget.PangoContext);
        layout.SetText(text);//add the text to thelayout.
        //this is the actuall rendering
        window.DrawLayout(gc, expose_area.X, expose_area.Y, layout);
    }
