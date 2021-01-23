    Image img = (Image)e.Row.FindControl("image1");
    DateTime received;
    DateTime read;
    DateTime.TryParse(e.Row.Cells[1].Text, received);   // If exception it will produce DateTime.MinValue
    DateTime.TryParse(e.Row.Cells[2].Text, read);
    if (received == DateTime.MinValue)
    {
        img.ImageUrl = "/images/Red.gif";
    }
    else if (read == DateTime.MinValue)
    {
        img.ImageUrl = "/images/Amber.gif";
    }
    else
    {
        img.ImageUrl = "/images/Green.gif";
    }
    img.Visible = true;
