    private void Form1_FormClosing( object sender, FormClosingEventArgs e )
    {
        if ( e.CloseReason == CloseReason.UserClosing )
        {
            returnfield = null;
            this.close();
        }
    }
