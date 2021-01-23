    foreach (GridDataItem item in grdHeader.EditItems)
                {
                    // if in editing mode
                    GridEditableItem edititem = (GridEditableItem)item.EditFormItem;
                    RadTextBox txtHeaderName = (RadTextBox)edititem.FindControl("txbId");
                    //otherwise
                    Label lbl= (Label)edititem.FindControl("lblId");
                    string id = lbl.Text;
                }
