    object missing = System.Reflection.Missing.Value;
    Excel.Pictures p = yourWorksheet.Pictures(missing) as Excel.Pictures;
    Excel.Picture pic = null;
    pic = p.Insert(yourImageFilePath, missing);
    pic.Left = YourLeftPosition;
    pic.Top = YourTopPosition;
