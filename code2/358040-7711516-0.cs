    try
                {
                   NorthwindDataContext db= new NorthwindDataContext();
                   var oList = db.Categories.Select(p => new { Categoryname = p.CategoryName }).ToList();                
                   dg.DataSource = oList;
    
    
    
                    MessageBox.Show("OK"); 
                }
                catch (Exception ex)
                {
    
                    MessageBox.Show(ex.Message);   
                }
