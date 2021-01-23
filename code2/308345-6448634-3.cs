    WorkbookPart wbp = doc.WorkbookPart;
    WorksheetPart wsp = wbp.WorksheetParts.First();
    
    SheetViews sheetviews = wsp.Worksheet.GetFirstChild<SheetViews>();
    SheetView sv = sheetviews.GetFirstChild<SheetView>();
    Selection selection = sv.GetFirstChild<Selection>();
    Pane pane = new Pane(){ VerticalSplit = 1D, TopLeftCell = "A2", ActivePane = PaneValues.BottomLeft, State = PaneStateValues.Frozen };
    sv.InsertBefore(pane,selection);
    selection.Pane = PaneValues.BottomLeft;
