    // Appearance as a label
    var subscriptFont = new System.Drawing.Font(
                            richTextBox1.Font.FontFamily, 
                            richTextBox1.Font.Size - 2);
    richTextBox1.BackColor = System.Drawing.SystemColors.Control;
    richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
    richTextBox1.ReadOnly = true;
    richTextBox1.Text = "C1, C2, C3";
    // subscript 1
    richTextBox1.Select(1, 1);
    richTextBox1.SelectionCharOffset = -3;
    richTextBox1.SelectionFont = subscriptFont;
    // subscript 2
    richTextBox1.Select(5, 1);
    richTextBox1.SelectionCharOffset = -3;
    richTextBox1.SelectionFont =subscriptFont;
    // subscript 3
    richTextBox1.Select(9, 1);
    richTextBox1.SelectionCharOffset = -3;
    richTextBox1.SelectionFont = subscriptFont;
    subscriptFont.Dispose();
