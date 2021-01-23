    private bool busySizing;
    private void tbcTests_Resize( object sender, EventArgs e )
    {
        if (busySizing) return;
        busySizing = true;
        try {
           tbcTests.ItemSize = new Size(
              tbcTests.Width - tbcTests.TabPages[0].Controls[0].Width - tbcTests.Padding.X,
              tbcTests.ItemSize.Height );
        }
        finally {
           busySizing = false;
        }
    }
