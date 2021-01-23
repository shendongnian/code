    System.Web.UI.HtmlControls.HtmlGenericControl div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
    
    HtmlGenericControl literal = new HtmlGenericControl("div");
    literal.InnerHtml = reader.GetString(0);
    
    Image img = new Image();
    img.ImageUrl = "~/userdata/2/uploadedimage/batman-for-facebook.jpg";
    img.AlternateText = "Test image";
    div.Controls.Add(img);
    div.Controls.Add(literal);
    test1.Controls.Add(div);
