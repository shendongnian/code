    using (TestHierarchyEntities context = new TestHierarchyEntities())
            {
                    var category = (from c in context.context
                                    select new { c.ID, c.Desc }).ToList();
    
                    DropDownList1.DataValueField = "MID";
                    DropDownList1.DataTextField = "MDesc";
                    DropDownList1.DataSource = category;
                    DropDownList1.DataBind();                
             }
