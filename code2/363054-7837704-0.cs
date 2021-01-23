    List<WebControl> ctrlList = PlaceHolder1.Controls.Cast<WebControl>().ToList();
    foreach (WebControl ctrl in ctrlList)
    {
        ctrl.Visible = false;
    }
