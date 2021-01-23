    foreach (InlineShape shape in d.InlineShapes)             
    { 
        if (shape != null)
        {
            shape.Range.Select(); 
            d.ActiveWindow.Selection.Copy();
            Bitmap bitmap = new Bitmap(Clipboard.GetImage());
        }
    }
