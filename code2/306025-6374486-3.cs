    public void btnGatherLabels_Click(object sender, EventArgs e)
    {
        var myLabelCols = listView1.Items
            .Where(i => i.ItemType == ListViewItemType.DataItem)
            .Select(a => 
                a.Controls.Cast<Control>()
                    .Where(b => b.GetType().Equals(typeof(Label)))
            );
        foreach (var myLabels in myLabelCols)
            foreach (Label myLabel in myLabels)
                Response.Write(string.Concat(myLabel.Text, "<br />"));
    }
