    private void btnOk_Click(object sender, EventArgs e)
    {
        this.salesTax = txtPercent.Text;  //--> frmInvoiceTotal will read this after the OK button is clicked
        txtPercent.Text = "";
        Hide();
    }
