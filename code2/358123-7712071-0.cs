     NorthwindDataContext db= new NorthwindDataContext();
                   db.Log = sw;
                   var oList = db.Categories
                       .Where(j =>
                                ( string.IsNullOrWhiteSpace(txtName.Text) || j.CategoryName.StartsWith(txtName.Text.Trim()))
                                &&
                                (string.IsNullOrWhiteSpace(txtDescription.Text) || j.Description.StartsWith(txtDescription.Text.Trim()))   
                              )
                       .Select(p => new { Name = p.CategoryName ,Description =p.Description }).ToList();  
