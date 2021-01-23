    public int TextBox_Validation(string value)
    {
        int integer = 0;
        if( string.IsNullOrEmpty( value ) )
        {
            MessageBox.Show( "Please enter a value" );    
        }
        else
        {
            int.TryParse( value, out integer );
        }
        return integer;
    }
