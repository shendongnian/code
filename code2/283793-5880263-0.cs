    protected void BtnAddProduct_Click(object sender, EventArgs e)
    {
        switch (DdlProductList.SelectedValue)
        {
            case "1":
                PanelEpl.Visible = true;
                break;
            case "2":
                PanelProf.Visible = true;
                break;
            case "3":
                PanelCrime.Visible = true;
                break;
            case "4":
                PanelFid.Visible = true;
                break;
            case "5":
                PanelNotProf.Visible = true;
                break;
            case "6":
                PanelPriv.Visible = true;
                break;
            case "7":
                PanelPub.Visible = true;
                break;
            default:
                break;
        }
    }
     protected void DdlProductList_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlProductList.Items.Remove(DdlProductList.SelectedItem);
    }
