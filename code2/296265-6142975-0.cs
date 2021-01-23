    for (int index = PocDiagnoses.MIN_DIAGNOSIS; index <= PocDiagnoses.MAX_DIAGNOSIS; index++) 
    {
        foreach (RepeaterItem ri1 in GeneralRepeater.Items)
        {
            int iItemIndex = ri1.ItemIndex;
            DropDownList myDDL = (DropDownList)GeneralRepeater.Items[iItemIndex].FindControl("GeneralDDL");
            MyPoc.Diagnoses.Diagnoses[index] = new PatientDiagnosis(myDDL.SelectedValue, new SynergyOnSetDate(new System.DateTime(Year, Month, Day)), "01/02/2011");
            break;
        }
    
        // Check the index variable here.
    }
