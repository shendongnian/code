    for(int i = 0; i < panels.length; i++){
        AddPanel(panels[i], i);
    }
    AddPanel(System.Drawing.Point point, int tabIndex){
        Panel panel = new Panel();
        this.Add(panel);
        panel.Controls.Add(new Button());
        panel.Controls.Add(new Label("Image"));
        panel.Controls.Add(new Label("Name"));
        panel.Controls.Add(new Label("linkName"));
        panel.Controls.Add(new Label("linkLocation"));
        panel.Controls.Add(new Label("location"));
        panel.Location = point;
        panel.Name = "panel" + i.ToString();
        panel.Size = new System.Drawing.Size(506, 100);
        panel.TabIndex = tabIndex;
    }
