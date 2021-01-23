    HtmlGenericControl unorderedList = new HtmlGenericControl("ul");
    
    HtmlGenericControl tempItem = null;
    HtmlGenericControl tempAnchor = null;
    
    foreach (Company item in company)
    {
         tempItem = new HtmlGenericControl("li");
         unorderedList.Controls.Add(tempItem);
         
         tempAnchor = new HtmlGenericControl("a");
         tempAnchor.Controls.Add(new Literal { Text = item.Name });
         tempItem.Controls.Add(tempAnchor);
    }
