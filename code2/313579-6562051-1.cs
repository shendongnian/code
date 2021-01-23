    // bind the PropertyTable to PropertyGrid
    this.pg_Prefs.SelectedObject = proptable;
    // get selected item
    GridItem gi = this.pg_Prefs.SelectedGridItem;
    // get category for selected item
    GridItem pgi = gi.Parent.Parent;
    //sort categories
    List<GridItem> sortedCats = new List<GridItem>(pgi.GridItems.Cast<GridItem>());
    sortedCats.Sort(delegate(GridItem gi1, GridItem gi2) { return gi1.Label.CompareTo(gi2.Label); });
    // loop to first category
    for (int i = 0; i < pgi.GridItems.Count; i++)
    {
        if (pgi.GridItems[i] == gi) break; // in case full circle done
        // select if first category
        if (pgi.GridItems[i].Label == sortedCats[0].Label)
        {
             pgi.GridItems[i].Select();
             break;
        }
    }
    
