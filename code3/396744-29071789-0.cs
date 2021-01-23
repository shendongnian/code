    Shape sh = myWorksheet.Shapes.AddPicture("...\\Images\\test.png",
                                        Microsoft.Office.Core.MsoTriState.msoCTrue, Microsoft.Office.Core.MsoTriState.msoCTrue,
                                        603,116, 162, 221); // Set Left,Top,Width, height
        sh.Placement = XlPlacement.xlFreeFloating;
        sh.TextFrame.Characters(Type.Missing, Type.Missing).Insert("This is sample text !!");
                            sh.TextFrame.Characters(Type.Missing, Type.Missing).Font.Size = 13;
        sh.TextFrame.Orientation = Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal;
        sh.TextFrame.VerticalAlignment = XlVAlign.xlVAlignCenter;
        sh.TextFrame.HorizontalAlignment = XlHAlign.xlHAlignLeft;
        sh.TextFrame.Characters(Type.Missing, Type.Missing).Font.ColorIndex = 2;
        sh.TextFrame.HorizontalAlignment = XlHAlign.xlHAlignCenter;
        
        int titleBg = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(51, 204, 204));
        sh.Fill.ForeColor.RGB = titleBg;
        sh.Fill.ForeColor.SchemeColor = 41;
        sh.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
