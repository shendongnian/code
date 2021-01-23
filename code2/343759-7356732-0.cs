    using System;
    using System.IO;
    using Gtk;
    
    public partial class MainWindow : Gtk.Window
    {
    	private static Gdk.Atom _atom = Gdk.Atom.Intern("CLIPBOARD", false);
    	private Gtk.Clipboard _clipBoard = Gtk.Clipboard.Get(_atom);
    	private Gtk.FileChooserButton _fileCopy = null;
    	private Gtk.FileChooserButton _folder = null;
    	private Gtk.RadioButton _radioCopy = null;
    	private Gtk.RadioButton _radioMove = null;
    	private System.Text.ASCIIEncoding _encoding = new System.Text.ASCIIEncoding();
    	private string _action = null;
    	private string _source = null;
    	private string _destination = null;
    	
    	public MainWindow () : base(Gtk.WindowType.Toplevel)
    	{
    		SetDefaultSize(200, -1);
    						
    		var table = new Gtk.Table(5, 5, true);
            var separator = new Gtk.HSeparator();
    		
    		var label0 = new Gtk.Label("Select file to copy/move");
            _fileCopy = new Gtk.FileChooserButton("Select A File", Gtk.FileChooserAction.Open);
            _radioCopy = new Gtk.RadioButton("Copy");
            _radioMove = new Gtk.RadioButton(_radioCopy, "Move");
            var copyButton = new Gtk.Button("Copy");
    
    		Add(table);
            		
    		table.Attach(label0, 0, 4, 0, 1);
            table.Attach(_fileCopy, 0, 1, 1, 2);
            table.Attach(_radioCopy, 1, 2, 1, 2);
            table.Attach(_radioMove, 2, 3, 1, 2);
            table.Attach(copyButton, 3, 4, 1, 2);
            table.Attach(separator, 0, 4, 2, 3);
            
            var label1 = new Gtk.Label("Select destination for file(s)");
            _folder = new Gtk.FileChooserButton("Select A File", Gtk.FileChooserAction.SelectFolder);
            var pasteButton = new Gtk.Button("Paste");
            
            table.Attach(label1, 0, 4, 3, 4);
            table.Attach(_folder, 0, 1, 4, 5);
            table.Attach(pasteButton, 3, 4, 4, 5);
            
    		DeleteEvent += OnDeleteEvent;
    		copyButton.Clicked += OnCopyButtonClick; 
    		pasteButton.Clicked += OnPasteButtonClick;
    				
    		ShowAll();
    	}
    	
    	private void ClearGet(Gtk.Clipboard clipboard, Gtk.SelectionData selection, uint info)
    	{
    		var temp = _action + "\n" + _source;
    		selection.Set(selection.Target, 8, _encoding.GetBytes(temp)); 
    	}
    	
    	private void ClearFunc(Gtk.Clipboard clipboard)
    	{
    		//???
    	}
    
    	private void ReceivedFunc(Gtk.Clipboard clipboard, Gtk.SelectionData selection)
    	{
    		var temp = _encoding.GetString(selection.Data);
    		if (temp==null) return;
    		
    		var items = temp.Split();
    		for (int i=1; i<items.Length; i++)
    		{
    			var fileFrom = items[i].Substring("file://".Length);
    			var fileTo = System.IO.Path.Combine(_destination, System.IO.Path.GetFileName(fileFrom));
    			if (items[0]=="copy")
    				File.Copy(fileFrom, fileTo);
    			else if (items[1]=="cut")
    				File.Move(fileFrom, fileTo);
    		}
    	}
    	
    	private void OnCopyButtonClick(object obj, EventArgs args)
    	{
    		Console.WriteLine(_fileCopy.Uri);
    		
    		_source = _fileCopy.Uri;
    		_action = _radioMove.Active ? "cut" : "copy";
    		
    		var target0 = new TargetEntry("x-special/gnome-copied-files", 0, 0);
    		var target1 = new TargetEntry("text/uri-list", 0, 0);
    		
    		_clipBoard.SetWithData(new TargetEntry[] {target0, target1}, ClearGet, ClearFunc);
    	}
    	
    	private void OnPasteButtonClick(object obj, EventArgs args)
    	{
    		_destination = _folder.Filename;
    		_clipBoard.RequestContents(Gdk.Atom.Intern("x-special/gnome-copied-files", false), ReceivedFunc);
    	}
    	
    	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
    	{
    		Application.Quit ();
    		a.RetVal = true;
    	}
    }
