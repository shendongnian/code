        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //reference the repeater item.
            RepeaterItem item = e.Item;
            //reference the controls.
            Label lbltotal = (item.FindControl("lblgoldname") as Label);
            Label lblamount = (item.FindControl("lblgoldDonationAmount") as Label);
            if (lbltotal.Text.ToUpper() == "TOTAL")
            {
                int footerindex = e.Item.ItemIndex;
                HtmlTableRow htmlrow = (HtmlTableRow)e.Item.FindControl("trgold");
                htmlrow.BgColor = "#DDCECB";
                lbltotal.Style.Add("Font-Weight", "bold");
                lbltotal.Style.Add("color", "cadetblue");
                lblamount.Style.Add("Font-Weight", "bold");
                lblamount.Style.Add("color", "cadetblue");
            }
        }
    }
