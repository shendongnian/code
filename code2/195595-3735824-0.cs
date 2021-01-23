    private void Form1_FormClosing( object sender, FormClosingEventArgs e )
    {
        if ( e.CloseReason == CloseReason.UserClosing )
        {
            if ( MessageBox.Show( this, "Really?", "Closing...",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question )
                == DialogResult.Cancel ) e.Cancel = true;
        }
    }
