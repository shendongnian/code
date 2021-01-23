    public PassData passdata = null;
    private void ViewList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(passdata != null)
        {
          passdata(ViewList.FocusedItem);
        }
    }
