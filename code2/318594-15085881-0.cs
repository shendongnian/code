    var img = Image.FromFile(row.ItemArray[i].ToString().Split(';')[1]);
    var pic = wrksht.Drawings.AddPicture((_rows + i * new Random(_rows + i).Next()).ToString(), img);
    //pic.SetSize(img.Width + 5, img.Height + 5);
    //pic.From.Column = i + 1;
    //pic.From.Row = _rows;
    //pic.From.RowOff = ExcelHelper.Pixel2MTU(1);
    //pic.From.ColumnOff = ExcelHelper.Pixel2MTU(1);
    pic.SetPosition(_rows-1, 0, i, 0); // always one less than actual value
