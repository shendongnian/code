    //Same code as you already have...
    SqlDataAdapter da = new SqlDataAdapter(command);
    DataTable dt = new DataTable();
    da.Fill(dt);
    
    List<CustomUserObject> userList = new List<CustomUserObject>();
    foreach (DataRow dr in dt.Rows)
    {
         //Create a class to house your user object before this next part will work.
         CustomUserObject cuo = new CustomUserObject { FirstName = dt.Rows[0]["FirstName"].ToString(), LastName = dt.Rows[0]["LastName"].ToString(), etc... };
         userList.Add(cuo);
    }
    
    ViewData.Model = userList;
    return View();
