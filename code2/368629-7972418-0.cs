    // Or IEnumerable<Forest>, depending on the type involved...
    IQueryable<Forest> query = Forest;
    if (ddlType1.SelectedValue!=null)
    {
        query = query.Where(trees => trees.Type1 == ddlType1.SelectedValue);
    }
    else if (ddlType2.SelectedValue!=null)
    {
        query = query.Where(trees => trees.Type2 == ddlType2.SelectedValue);
    }
    var finalQuery = query.OrderBy(trees => tree.Nuts)
                          .GroupBy(trees => trees.TrunkColour);
