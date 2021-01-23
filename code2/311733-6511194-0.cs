    int NumberOfTextBoxes = 11;
    TextBox[] DynamicTextBoxes = new TextBox[NumberOfTextBoxes];
    int ndx = 0;
    while (ndx < NumberOfTextBoxes) 
    {
        DynamicTextBoxes[ndx] = new TextBox();
        DynamicTextBoxes[ndx].Name = "TextBox" + ndx.ToString();
        // You can set TextBox value here:
        // DynamicTextBoxes[ndx].Text = "My Value";
        tableLayoutPanel1.Controls.Add(DynamicTextBoxes[ndx]);
        ndx++;
    }
