        Panel p = new Panel();
        p.Style["background-color"] = "#aaeeaa";
        p.ID = "childPanel";
        p.ClientIDMode = System.Web.UI.ClientIDMode.Static;
        p.Controls.Add(new LiteralControl("<div id=\"div111\" runat=\"server\">Hello, world!</div>"));
        declaredPanel.Controls.Add(p);
        Panel p2 = declaredPanel.FindControl("childPanel") as Panel;
        string colorCode = p2.Style["background-color"]; // reports "#aaeeaa"
