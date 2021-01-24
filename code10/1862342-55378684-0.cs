    public void plus(int n)
    {
        labelsArray[n].Visible =
        comboboxArray[n].Visible =
        plusButtonArray[n].Visible =
        minusButtonArray[n].Visible = true;
    }
    private void plus1_Click(object sender, EventArgs e)
    {
        plus(1);
    }
