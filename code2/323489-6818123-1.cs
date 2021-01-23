    string updateCOM_ID = e.Item.Cells[2].Text;
    string updateCompany = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
    double updatePrice = double.Parse(((TextBox)e.Item.Cells[4].Controls[0]).Text);
    string updateModel = ((TextBox)e.Item.Cells[5].Controls[0]).Text;
    string updateDescription = ((TextBox)e.Item.Cells[6].Controls[0]).Text;
    int updateCategoryId = int.Parse(e.Item.Cells[7].Text);
    string updateImage = ((TextBox)e.Item.Cells[8].Controls[0]).Text;
    int updateQuantity = int.Parse(e.Item.Cells[9].Text);
