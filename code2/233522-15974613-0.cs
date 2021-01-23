    if (!File.Exists("singleright.png"))
    {
    object obj = Properties.Resources.singleright;
    System.Drawing.Bitmap rs = (System.Drawing.Bitmap)(obj);
    rs.Save("singleright.png");
    }
    insertionPoint.InlineShapes.AddPicture("singleright.png", ref LinkToFile, ref SaveWithDocument);
