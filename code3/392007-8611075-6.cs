    protected void Save_Click(object sender, EventArgs e) 
    {
      foreach(ListViewItem item in DynamicFields.Items)
      {
        TextBox field = item.FindControl("Field") as TextBox;
        string id = field.Attributes["data-field-id"];
        string value = field.Text;
      }
    }
