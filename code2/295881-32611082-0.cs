	private void dataLinkDialogButton_Click(object sender, System.EventArgs e)
	{
	    ADODB.Connection conn = new ADODB.Connection( );
	    object oConn = (object) conn;
	    MSDASC.DataLinks dlg = new MSDASC.DataLinks( );
	    dlg.PromptEdit(ref oConn);
	    connectionStringTextBox.Text = conn.ConnectionString;
	}
