    // reduce everything like Ctrl+M+O
    _applicationObject.ExecuteCommand("Edit.CollapsetoDefinitions");
    
    // save the cursor position
    TextSelection selection = (TextSelection)_applicationObject.ActiveDocument.Selection;
    var selectedLine = selection.ActivePoint.Line;
    var selectedColumn = selection.ActivePoint.DisplayColumn;
    
    // open the regions
    selection.StartOfDocument();
    while (selection.FindText("#region", (int)vsFindOptions.vsFindOptionsMatchInHiddenText))
    {
        // do nothing since FindText automatically expands any found #region
    }
    
    // put back the cursor at its original position
    selection.MoveToDisplayColumn(selectedLine, selectedColumn);
