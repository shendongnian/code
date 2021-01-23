    for ( int i = 0; dt2 != null && i < dt2.Rows.Count; ++i )
    {
        String tmp = dt2.Rows[ i ]["staff_AccessCode"].ToString();
        if ( tmp.Equals( what_ever_variable_or_constant /* e.g., txtbox.Text */ ) )
        {
            accessname = tmp;
            //break; ?
        }
    }
