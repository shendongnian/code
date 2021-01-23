    lkpReference.Properties.DataSource = _lab.selectLabReference() ;
    lkpReference.Properties.DisplayMember = "refernce_name";
    lkpReference.Properties.ValueMember = "lab_ref_id";
    lkpReference.Properties.BestFitMode = BestFitMode.BestFit;
    lkpReference.Properties.SearchMode = SearchMode.AutoComplete;
    
    // the constructor you are using accepts 2 parameters: FieldName (which is the name
    // of the field from the DataTable) and Width (which is the width of the column
    // displayed in the dropdown). You have set both of these parameters wrong.
    //LookUpColumnInfoCollection collns = lkpReference.Properties.Columns;
    //collns.Add(new LookUpColumnInfo("Lab Reference", 0));
    // i think what you intended to do is this
    lkpReference.Properties.Columns.Add(new LookUpColumnInfo("refernce_name", 100, "Lab Reference"));
    
    lkpReference.Properties.AutoSearchColumnIndex = 1;
