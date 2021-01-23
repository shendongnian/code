    public void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
      var users = (from user in dataContext.tbl_files
                  select new { user.File_Name, user.Upload_Time, user.Uploaded_By }).ToList().AsEnumerable();
    
      switch(e.SortExpression)
      {
         case "File_Name":
           users = users.OrderBy(x => x.File_Name);
           break;
         case "Upload_Time":
           users = users.OrderBy(x => x.Upload_Time);
           break;
         case "Uploaded_By":
           users = users.OrderBy(x => x.Uploaded_By);
           break;
      }
      if(e.SortDirection == SortDirection.Descending)
        users = users.Reverse();
    
      GridView1.DataSource = users;
      GridView1.DataBind();
    }
