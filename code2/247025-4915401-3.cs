    protected void btnDownload_Click( object sender, EventArgs e )
    {
      foreach( ListViewDataItem item in ListView1.Items )
      {
        var chk = item.FindControl( "MyCheckBox" ) as System.Web.UI.HtmlControls.HtmlInputCheckBox;
        if( chk != null && chk.Checked )
        {
          string value = chk.Value;
        }
      }
    }
