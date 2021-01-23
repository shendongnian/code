    UpdatePanel up1 = new UpdatePanel();
    up1.ID = "UpdatePanel1";
    Button button1 = new Button();
    button1.ID = "Button1";
    button1.Text = "Submit";
    button1.Click += new EventHandler(Button_Click);
    up1.ContentTemplateContainer.Controls.Add(button1);
    Page.Form.Controls.Add(up1);
