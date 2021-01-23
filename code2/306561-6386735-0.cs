        protected void DataList1_ItemCommand(object sender, DataListCommandEventArgs e) {
            if (e.Item.ItemType == ListItemType.Footer) {
                if (e.CommandName == "AddContinue") {
                    foreach (DataListItem item in DataList1.Items) {
                        CheckBox extraCheck
                            = item.FindControl("extraCheck") as CheckBox;
                        if (extraCheck != null) {
                            if (extraCheck.Checked) {
                                Response.Write(item.ItemIndex);
                            }
                        }
                    }
                } else if (e.CommandName == "SkipContinue") {
                }
            }
        }
