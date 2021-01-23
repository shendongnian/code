    List<Categories> myList = new List<Categories>();
    foreach (GridViewRow row in grdCategory.Rows)
    {
        Categories newCat = new Categories();
        Label catID = row.FindControl("lblCatID") as Label;
        newCat.catID = Convert.ToInt32(catID.Text);
        ...
        ...
        myList.Add(newCat);
    }
