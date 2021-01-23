    const int _editColumnIndex = 0;
    void Page_Load(object sender, EventArgs e)
    {
      if(!User.IsInRole("Manager"))    
          grdMovies.Columns[_editColumnIndex].Visible = false;
    }
