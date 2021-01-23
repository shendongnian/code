    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
            {
                if (e.CommandName == "TestConnection")
                {               
                    var FormItem = e.Item as GridDataItem;
                    if (FormItem == null)
                        throw new Exception("GridDataItem is null");
                    var serverNameTextBox = FormItem.EditFormItem.FindControl("tbServerName") as TextBox;
            }
    
    }
