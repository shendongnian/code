    protected void LinkFile(object sender, EventArgs e)
    {
       if (!string.IsNullOrEmpty(txtLinkFileName.Text))
       {
          if (txtLinkFileName.Text.Length > 2 && txtLinkFileName.Text.Substring(0, 2) != @"\\")
          {
             Code.Common.DisplayMessage("File must be in a shared location!", Page);
          }
          else
          {
             //just a link to a file - no need to upload anything
             //save filepath to database
             //filepath = txtLinkFileName.Text;
          }
       }
    }
