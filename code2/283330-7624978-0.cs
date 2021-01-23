      ListStore SetupModel( TreeView tv ){
        var m = new ListStore(typeof(string),typeof(string));
    
        var nameCol = new TreeViewColumn( "Name", 
          new CellRendererText(), "text", 0 );
        tv.AppendColumn( nameCol );
    
        var colourCol = new TreeViewColumn( "Colour", 
          new CellRendererText(), "text", 1 );
        tv.AppendColumn( colourCol );
    
        tv.Model = m;
        return m;
      }
    
      void PopulateData( ListStore model ) {
        model.AppendValues( "Fred", "Blue" );
        model.AppendValues( "Bob", "Green" );
        model.AppendValues( "Mary", "Yellow" );
        model.AppendValues( "Alice", "Red" );
      }
