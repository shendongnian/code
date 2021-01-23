         //setup the template 
         GridViewTemplate subtemplate = new GridViewTemplate();
         subtemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
         subtemplate.EnableFiltering = false;
         subtemplate.EnableGrouping = false;
         subtemplate.AutoGenerateColumns = false;
    
         //define / add the cols
         GridViewTextBoxColumn atextcol = new GridViewTextBoxColumn("Name");
         //further properties of atextcol
         
          //add the cols to the template
          subtemplate.Columns.Add(atextcol);
    
          //add the template to the grid
          thegrid.Templates.Add(subtemplate);
         
         //add a HierarchyDataProvider && subscribe to the RowSourceNeeded-Event
          subtemplate.HierarchyDataProvider = new GridViewEventDataProvider(subtemplate);
     
          thegrid.RowSourceNeeded += new GridViewRowSourceNeededEventHandler(thegrid_RowSourceNeeded);
               
