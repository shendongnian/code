    protected void button1_Click( object sender, EventArgs args )
    {
        var h = Click;
        if ( h != null )
        {
            h( this, args );
        }
    }
