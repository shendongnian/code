        List<Control> ctrl = new List<Control>();
        HtmlAnchor anchor = new HtmlAnchor();
        anchor.ID = "myAnchor";
        ctrl.Add(anchor);
        Button btn = new Button();
        btn.ID = "MyBtn";
        ctrl.Add(btn);
        foreach (Control c in ctrl.ToList())
        {
            if (c is Button)
            {
                // Do Something
            }
        }
