    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        var purchase = new DrinkPurchase(txtUserName.Text, txtCompanyName.Text);
        var coffee = new DrinkSelection 
        { 
            Name = lblCoffee.Text, 
            Qty = ddlCoffee.SelectedValue 
        };
        var tea = new DrinkSelection 
        { 
            Name = lblEnglishTea.Text, 
            Qty = ddlEnglishTea.SelectedValue 
        };
        purchase.Save(coffee);
        purchase.Save(tea);
    }
