    	Widget1 win1 = new Widget1();
		
        HBox hbox = new HBox();
        hbox.PackStart(new Label("Pane 1") );
        Button close = new Button("×"); // Set this up with an image or whatever.
        close.Relief = ReliefStyle.None;
        close.FocusOnClick = false;
        close.Clicked += delegate {
            hbox.Destroy();
            win1.Destroy();
        };
       
        hbox.PackStart(close);
        hbox.ShowAll();
        nbMain.AppendPage(win1, hbox);
		win1.Show();
