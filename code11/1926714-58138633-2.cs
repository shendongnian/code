    //Avoid inivisble columns (width 0) beeing stuck somewhere in between. 
    //push them all to the front, cause no one will try to expand the "0st Column".
    foreach (ColumnHeader ch in this.extendedListView.Columns)
    {
        //DisplayIndex not known?
        if (!keyToIndex.ContainsKey(ch.Name))
        {
            ch.DisplayIndex = 0;
            ch.Width = 0;
        }
    }
