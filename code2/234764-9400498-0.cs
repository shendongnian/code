    DataView dv = null;
    CurrencyManager cm = (CurrencyManager)(dgv.BindingContext[dgv.DataSource, dgv.DataMember]);
    if (cm.List is BindingSource)
    {
        // In case of BindingSource it may be chain of BindingSources+relations
        BindingSource bs = (BindingSource)cm.List;
        while (bs.List is BindingSource)
        { bs = bs.List as BindingSource; }
        if (bs.List is DataView)
        { dv = bs.List as DataView; }
    }
    else if (cm.List is DataView)
    {
        // dgv bind to the DataView, Table or DataSet+"tablename"
        dv = cm.List as DataView;
    }
    if (dv != null)
    {
        dv.Sort = "somedate desc, firstname";
        // dv.Filter = "lastname = 'Smith' OR lastname = 'Doe'";
        //  You can Set the Glyphs something like this:
        int somedateColIdx = 5;    // somedate
        int firstnameColIdx = 3;   // firstname
        dgv.Columns[somedateColIdx].HeaderCell.SortGlyphDirection = SortOrder.Descending;
        dgv.Columns[firstnameColIdx].HeaderCell.SortGlyphDirection = SortOrder.Ascending;
    }
