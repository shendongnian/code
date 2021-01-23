    Response.ClearContent(); 
    Response.ContentType = "application/ms-excel"; 
    Response.AddHeader("content-disposition", "attachment; filename=orders.xls");
    
    Response.Write(a.DisplayTable());
    
    Response.End();
