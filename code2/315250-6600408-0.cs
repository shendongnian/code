    for( int i = 0; i < upperLimit; i++ )
    {
        TextBox control = Page.FindControl("tbNumber" + i) as TextBox;
        if( control != null ) {
            // do what you need to do here
            string foo = control.Text;
        }
    }
