    private void button1_Click( object sender, EventArgs e )
    {
        b obj = new b();
        var props = obj.GetType().GetProperties( BindingFlags.Public );
        var prop = obj.GetType().GetProperty( "Description", 
            BindingFlags.Static |
            BindingFlags.FlattenHierarchy |
            BindingFlags.Public
            );
        MessageBox.Show( prop.GetValue( obj, null ).ToString() );
    }
