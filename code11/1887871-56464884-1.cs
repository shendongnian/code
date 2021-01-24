    List<DataGridView> gridViews = new List<DataGridView>();
    foreach (Control c in Controls)
    {
        if (c is DataGridView)
        {
            gridViews.Add((DataGridView)c);
        }
    }
    foreach (DataGridView dataGridView in gridViews)
    {
        dataGridView.Rows.Add(txtEmployeerName.Text, txtReferenceNumber.Text, txtPurchaseAmount.Text, txtPaymentDate.Text, txtPaymentAmount.Text, txtPartOne.Text, txtPartTwo.Text, txtPartThree.Text, txtPartFour.Text, txtPartFive.Text, txtRemainingDebt.Text);
    }
