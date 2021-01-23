    If(IsPostBack)
    {
      string firstName = Request.Forms["firstname"];
      string surName = Request.Forms["surname"];
    
    if(string.IsNullOrEmpty(firstName))
    {
    Response.Write("Firstname is required");
    }
    }
