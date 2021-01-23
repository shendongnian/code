    private void SetCombobValueByUIA( AutomationElement ctrl, string newValue )
    { 
        ExpandCollapsePattern exPat = ctrl.GetCurrentPattern(ExpandCollapsePattern.Pattern) 
                                                                  as ExpandCollapsePattern;
        if( exPat== null )
        {
            throw new ApplicationException( "Bad Control type..." );
        }
        exPat.Expand();
        AutomationElement itemToSelect = ctrl.FindFirst(TreeScope.Descendants, new
                              PropertyCondition(AutomationElement.NameProperty,newValue));
        SelectionItemPattern sPat = itemToSelect.GetCurrentPattern(
                                                  SelectionItemPattern.Pattern)  as SelectionItemPattern ; 
        sPat. Select();
    }
