    aDoc.Application.ActiveDocument.Shapes.get_Item("Rectangle 6").Select(); //finds the 1st image
                aDoc.Application.Selection.MoveDown(WdUnits.wdScreen, 2);// adds tow pagedown presses
                aDoc.Application.Selection.InlineShapes.AddPicture(@"C:\fullImagePath\Image.JPG");//adds image on new page
                aDoc.Application.Selection.InsertBreak(WdBreakType.wdPageBreak);//adds a page break
                aDoc.Application.Selection.InlineShapes.AddPicture(@"C:\fullImagePath\Image.gif");//adds image on new page
