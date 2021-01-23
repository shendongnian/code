    // Object heirarchy:
    // DrawingGroup (whole thing)
    //  - DrawingGroup (lines)
    //     - GlyphRunDrawing.GlyphRun.Characters (parts of lines)
    // Note, if text is clipped, the ellipsis will be placed in its own 
    // separate "line" below.  Give it a try and you'll see what I mean.
    List<DrawingGroup> lines = drawing.Children.OfType<DrawingGroup>().ToList();
    foreach (DrawingGroup line in lines)
    {
        List<char> lineparts = line.Children
            .OfType<GlyphRunDrawing>()
            .SelectMany(grd => grd.GlyphRun.Characters)
            .ToList();
        string lineText = new string(lineparts.ToArray());
        Debug.WriteLine(lineText);
    }
