     FindingViwerDisplay uc =  (FindingViwerDisplay)LoadControl("FindingViwerDisplay.ascx");                 
     FindingPlaceholder.Controls.Add(uc);
    for (int i = 0; i < FindingsViewerNew.Count; i++)
     { 
   
     uc.displayFindingSection(Convert.ToInt32(FindingsViewerNew[i].Index), FindingsViewerNew[i].Text,   FindingsViewerNew[i].Title);
     }
