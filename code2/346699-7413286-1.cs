    object missing = System.Reflection.Missing.Value;
    Excel.Range picPosition = GetPicturePosition(); // retrieve the range for picture insert
    Excel.Pictures p = yourWorksheet.Pictures(missing) as Excel.Pictures;
    Excel.Picture pic = null;
    pic = p.Insert(yourImageFilePath, missing);
    pic.Left = Convert.ToDouble(picRange.Left);
    pic.Top = picRange.Top;
    pic.Placement = // Can be any of Excel.XlPlacement.XYZ value
