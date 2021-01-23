    public override DocumentPage GetPage(int pageNumber)
    {
        for (int i = 0; i < children.Count; i++)
        {
            if (pageNumber >= pageCounts[i])
                pageNumber -= pageCounts[i];
            else
                return FixFixedPage(children[i].GetPage(pageNumber));
        }
        if (pageNumber < PageCount)
        {
            DrawingVisual dv = new DrawingVisual();
            var dc = dv.Drawing.Append();
            dc = dv.RenderOpen();
            DoRender(pageNumber, dc); // some method to render stuff to the DrawingContext
            dc.Close();
            return new DocumentPage(dv);
        }
        return null;
    }
