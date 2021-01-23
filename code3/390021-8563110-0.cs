    Microsoft.Office.Interop.Word.Range CurrRange = Globals.ThisAddIn.Application.Selection.Range;
                 
    //Get the id of the MS Word shape to be inserted
    int shapeId = (int)MsoAutoShapeType.msoShapeRoundedRectangle;
    
    //Get the value of the name attribute from the selected tree view item
    string nodeText = "Hello World";
    
    var left = Globals.ThisAddIn.Application.Selection.get_Information(Microsoft.Office.Interop.Word.WdInformation.wdHorizontalPositionRelativeToPage);
    var top = Globals.ThisAddIn.Application.Selection.get_Information(Microsoft.Office.Interop.Word.WdInformation.wdVerticalPositionRelativeToPage);
               
    //Add a new shape to the MS Word designer and set shape properties
    var shape = CurrRange.Document.Shapes.AddShape(shapeId, left, top, 100, 20);
    shape.AlternativeText = String.Format("Alt {0}", nodeText);
    shape.TextFrame.ContainingRange.Text = nodeText;
    shape.TextFrame.ContainingRange.Font.Size = 8;
