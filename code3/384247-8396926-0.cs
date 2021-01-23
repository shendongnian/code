    TextBox newBox = new TextBox();
    newBox.ID = "newBox1";
    newBox.Width = "50px";
    ... (Set style, absolute location if needed, etc)
    newBox.Text = "This is a new dynamically created TB";
    div1.Controls.Add(newBox);
