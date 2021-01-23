     while (reader.Read())
     {
        var div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
        div.Attributes["class"] = "test";
        div.ID = String.Format("comment{0}", reader.GetString(0));
        Image img = new Image();
        img.ImageUrl = String.Format("{0}", reader.GetString(2));
        img.AlternateText = "Test image";
        div.Controls.Add(img);
        div.Controls.Add(ParseControl(String.Format("&nbsp&nbsp&nbsp;" + "{0}", reader.GetString(1))));
        // the single quotes in the line below are critical
        div.Attributes.Add("onclick", "return clickTheButton('" + div.ID + "');");
        div.Style["clear"] = "both";
        test1.Controls.Add(div);
