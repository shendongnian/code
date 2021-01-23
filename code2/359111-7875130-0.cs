    protected void dlstImage_ItemDataBound(object sender, DataListItemEventArgs e)// for disabling the image after moving
        {
            ImageButton imgctrl = (e.Item.FindControl("Image") as ImageButton);
            string[] str = imgctrl.CommandArgument.ToString().Split(';');
            SelImgId = Convert.ToInt32(str[0]);
            if (newpath.Exists(delegate(ArrayList imageDetails) { return Convert.ToInt32(imageDetails[0]) == SelImgId; }))
            {
                imgctrl.Enabled = false;
                imgctrl.CssClass = "tdDisable";
            }
            else
            {
                imgctrl.Enabled = true;
                imgctrl.CssClass = "";
            }
        }
