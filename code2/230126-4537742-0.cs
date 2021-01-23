    public void displayLinqCategory()
    {
        StoreDataContext dbm = new StoreDataContext();
        
        var query = dbm.Categories.Select(c=> new
        {
            Category = c,
            subCategories = dbm.SubCategories.Where(s=> s.CategoryID == c.CategoryID)  
        }).OrderBy(c=> c.Category.Name);
       
        resultSpan.InnerHtml += "<table class='tableStripe'>";
        resultSpan.InnerHtml += "<tr><th width='1%' colspan='2' style='text-align:left;'>ACTIVE</th><th style='text-align:left;'>NAME</th><th width='1%'>#Items</th></tr>";
        foreach (var result in query)
        {
            int i = result.Category.CategoryID;
            string active = string.Empty;
            bool s = result.Category.Active;
            if (s == true)
                active = "checked='checked'";
            else
                active = "";
            
            string catBox = string.Format("<input class='categoryChk'value='{0}' type='checkbox' {1} />", i,active);
            
            resultSpan.InnerHtml += "<tr><td>" + catBox + "</td><td colspan='2'><b>" + result.Category.Name + "</b></td><td></td></tr>";
            foreach (var sub in result.subCategories)
            {
                int si= sub.SubCategoryID;
                string sActive = string.Empty;
                bool subActive = sub.Active;
                if(subActive == true)
                    sActive = "checked='checked'";
                else
                    sActive ="";
                string subBox = string.Format("<input class='subCatChk' value='{0}' type='checkbox' {1} />", si, sActive);
                resultSpan.InnerHtml += "<tr><td style='background:#FFF;'></td><td>"+subBox+"</td><td>" + sub.SubCategoryName + "</td><td></td></tr>";
            }
        }
        resultSpan.InnerHtml += "</table>";          
    }
