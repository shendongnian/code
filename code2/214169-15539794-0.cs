    Vector curBaseline = renderInfo.GetBaseline().GetStartPoint();
    Vector topRight = renderInfo.GetAscentLine().GetEndPoint();
    iTextSharp.text.Rectangle rect = new iTextSharp.text.Rectangle(
        curBaseline[Vector.I1], curBaseline[Vector.I2], 
        topRight[Vector.I1], topRight[Vector.I2]
    );
    Single curFontSize = rect.Height;
