    var basket = new Basket();
    
    StringBuilder sb = new StringBuilder();
    StringWriter sw = new StringWriter(sb);
    
    using (HtmlTextWriter writer = new HtmlTextWriter(sw))
    {
       basket.RenderControl(writer);
    }
    
    string basketHtml = sb.ToString();
    
    newhtml =    templatehtml.Replace("{tag_shoppingcart}",   basketHtml);
