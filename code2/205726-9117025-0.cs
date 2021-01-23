     void ods_Updating(object sender, ObjectDataSourceMethodEventArgs e)
     {
        e.InputParameters.Remove("Type_ID");
        e.InputParameters.Remove("Document_ID");
        e.InputParameters.Remove("State_ID");
     }
