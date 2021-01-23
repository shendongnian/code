    Public DBContext Context 
    {
    get { 
    if(Session["DBContext"] == null)
        Session["DBContext"] = New Context();
    return Session["DBContext"]  as DBContext;
    }
