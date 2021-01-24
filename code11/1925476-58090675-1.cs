    private void btnPurchase_Click(object sender, EventArgs e)
    {
        string[] BOOKS;
        var sb = new StringBuilder();
        foreach(var item in BOOKS)
        {
            sb.Append($"\t{item}");
            sb.AppendNewLine();
        }
        MessageBox.Show("You Purchase :\n"
            + sb.ToString()//checked checkbox shows here
            + "The selected payment method is : " + payment
            + "\nYour comment about us : " + txtKomen.Text);
    }
