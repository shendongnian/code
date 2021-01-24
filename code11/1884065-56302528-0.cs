    private void frmMain_FormClosing ( object sender , FormClosingEventArgs e )
    {   // Update user settings, even if the cmdQuit_Click event was bypassed.
        if ( _intDesiredWidth > STRING_IS_EMPTY )
        {
            int intDefaultDesiredWidth;
            if ( int.TryParse ( Properties.Settings.Default.DesiredWidth , out intDefaultDesiredWidth ) )
            {
                if ( _intDesiredWidth != intDefaultDesiredWidth )
                {
                    Properties.Settings.Default.DesiredWidth = _intDesiredWidth.ToString ( );
                    Properties.Settings.Default.Save ( );   // Save only when there is something worth saving.
                }   // if ( _intDesiredWidth != intDefaultDesiredWidth )
            }   // if ( int.TryParse ( Properties.Settings.Default.DesiredWidth , out intDefaultDesiredWidth ) )
        }   // if ( _intDesiredWidth > STRING_IS_EMPTY )
    }   // private void frmMain_FormClosing
