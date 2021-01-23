     FindingViwerDisplay uc =  (FindingViwerDisplay)LoadControl("FindingViwerDisplay.ascx");                 
     FindingPlaceholder.Controls.Add(uc);
    //define here a dataTabel with three columns let say u have datatable dt
    for (int i = 0; i < FindingsViewerNew.Count; i++)
     { 
   
     dt.Rows.Add(Convert.ToInt32(FindingsViewerNew[i].Index), FindingsViewerNew[i].Text,   FindingsViewerNew[i].Title);
   
     }
      uc.displayFindingSection(dt);
