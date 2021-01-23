    TextBox[] allTextBoxes = { TxtBox1, TxtBox2, TxtBox3, TxtBox4 };
    void SetVisibility(TextBox visibleTextBox)
    {
        allTextBoxes.Except(new TextBox[] { visibleTextBox })
                    .ToList()
                    .ForEach(t => t.Visible = false);
        visibleTextBox.Visible = true;
    }
