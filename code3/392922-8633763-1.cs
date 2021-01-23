    for( int i = 0; i < 5; i++ )
    {
        TextBox tb = new TextBox();
        tb.ID = "txt" + i;
        this.Controls.Add( tb );
    
        Button btn = new Button();
        btn.ID = "btn" + i;
        this.Controls.Add( btn );
    
        btn.CommandArgument = i.ToString();
    
        btn.Command += ( sender, e )
        {
            string id = "txt" + e.CommandArgument;
            TextBox textBox = this.FindControl( id ) as TextBox;
        };
    }
