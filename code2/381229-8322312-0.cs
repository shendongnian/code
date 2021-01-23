    
    if (cell.Value.GetType() == typeof(Bitmap))
    {
        // You have to get original bitmap path here
        string imagString = "bitmap1.bmp";
        Excel.Range oRange = (Excel.Range)xlWorkSheet.Cells[i + 1, j + 1]; 
        float Left =(float) ((double)oRange.Left);
        float Top =(float) ((double)oRange.Top);
        const float ImageSize=32;
        xlWorkSheet1.Shapes.AddPicture(imagString, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);
        oRange.RowHeight = ImageSize + 2;
    }
    else
    {
        xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
    }
