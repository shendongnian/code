    else
        {
            int cat = Convert.ToInt32(ddlCategory.SelectedValue);
            SubCategory subCat = new SubCategory
            {
                SubCategoryName = name,
                Active = false,
                CategoryID = cat
            };
            db.SubCategories.InsertOnSubmit(subCat);
        }
