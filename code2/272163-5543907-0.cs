    if (!Page.IsPostback)
    {
      MyDropDownList.DataSource = blah;
      MyDropDownList.DataBind();
    }
    myTextBox.Text = MyDropDownList.SelectedValue;
