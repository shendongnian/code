    Image img = (Image)e.Row.FindControl("image1");
    int val = 0;
    int.TryParse(e.Row.Cells[1].Text , out val);
            switch (int.Parse(e.Row.Cells[1].Text))
            {
                case 0:
                    img.ImageUrl = "/images/Red.gif";
                    img.Visible = true;
                    break;
                case 1:
                    img.ImageUrl = "/images/Amber.gif";
                    img.Visible = true;
                    break;
                case 2:
                    img.ImageUrl = "/images/Green.gif";
                    img.Visible = true;
                    break;               
                default:
                    img.Visible = false;
                    break;
            }
