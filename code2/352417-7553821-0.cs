    for ( int i=0; i<4; i++ )
    {
       Button t = new Button();
       t.ID = "name" + i.ToString();
       t.Click += name_Click;
       this.Controls.Add( t );
    }
    ...
    protected void name_Click( object sender, EventArgs e )
    {
       Button clickedButton = (Button)sender;
    }
