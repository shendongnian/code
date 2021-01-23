    aDoc.Application.ActiveDocument.Shapes.get_Item("Rectangle 6").Select();
                aDoc.Application.Selection.MoveDown(WdUnits.wdScreen, 2);
                aDoc.Application.Selection.InlineShapes.AddPicture(@"C:\fullImagePath\Image.JPG");
                aDoc.Application.Selection.InsertBreak(WdBreakType.wdPageBreak);
                aDoc.Application.Selection.InlineShapes.AddPicture(@"C:\fullImagePath\Image.gif");
