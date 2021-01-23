    private static void AddImage(ExcelWorksheet ws, int rowIndex, String imageFile)
    {
        ExcelPicture picture = null;
        Bitmap image = new Bitmap(imageFile);
        if (image != null)
        {
            picture = ws.Drawings.AddPicture("pic" + rowIndex.ToString(), image);                
            picture.From.Column = 0;
            picture.From.Row = rowIndex-1;
            picture.SetSize(320, 240);
        }
    }
