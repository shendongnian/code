    FormViewRow row0 = FormView_Product.Row;
    string strProductId = ((Label)row0.FindControl("lblProductID")).Text;
    // Use TryParse in place of Parse; if the string is not parseable it will return false
    float unitPrice;
    float floUnitPrice = float.TryParse(((Lable)row0.FindControl("lblNormalPrice")).Text, out unitPrice) ? unitPrice : 0;
    // Use SelectedItem.Text instead of SelectedValue, as I didn't see any settings for Value in your markup, which might result in a blank string.
    int quantity;
    int intQty = int.TryParse(((DropDownList)row0.FindControl("DropDownList1")).SelectedItem.Text, out quantity) ? quantity : 0;
      
