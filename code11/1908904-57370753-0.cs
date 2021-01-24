    // we don't want redrawing on each removing (i.e. lvValid blicking)
    lvValid.BeginUpdate();
    
    try 
    {
        for (int i = 0; i < lvValid.Items.Count; ) // don't icrement i here... 
            if (DateTime.Now.AddDays(-3) > DateTime.Parse(lvValid.Items[i].SubItems[1].Text))
                lvValid.Items[i].Remove();
            else 
                ++i; // ... but there
    }
    finally 
    {
        // when finisihing removing, redraw lvValid if required 
        lvValid.EndUpdate();
    }
