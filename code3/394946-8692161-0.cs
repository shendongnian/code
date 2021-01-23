       GallaryImage g = new GallaryImage();
        var images = g.GetAll();
        photos.Style.Add("width","100%");
        photos.Style.Add("border-style","none");       
        int cntr = 0;
        TableRow row = new TableRow();
        foreach (var image in images)
        {
            cntr++;
            TableCell cell = new TableCell();
            Image i = new Image();
            i.ImageUrl = image.fullThumbPath;
            cell.Controls.Add(i);
            row.Cells.Add(cell);
            if(cntr%3==0)
            {
                photos.Rows.Add(row);
                row = new TableRow();
            }
        }
        if(row.Cells.Count > 0)
            photos.Rows.Add(row);
    }
