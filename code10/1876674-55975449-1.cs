    private void button1_Click(object sender, EventArgs e)
    {
        int n;
        // Validate input
        if (!int.TryParse(textBox1.Text, out n) || n < 0)
        {
            MessageBox.Show("Please enter a positive whole number");
            return;
        }
        // remove old buttons (except this one)
        var otherButtons = Controls.OfType<Button>().Where(b => b != button1).ToList();
        foreach (Button b in otherButtons)
        {
            Controls.Remove(b);
        }
        // Add button controls to form with these size and spacing values (modify as desired)
        var width = 25;
        var height = 25;
        var padding = 5;
        // For each row, increment the top by the height plus padding
        for (int row = 0, top = padding; row < n; row++, top += height + padding)
        {
            // For each column, increment the left by the width plus padding
            for (int col = 0, left = padding; col < n; col++, left += width + padding)
            {
                // Add our new button
                Controls.Add(new Button
                {
                    Top = top,
                    Left = left,
                    Width = width,
                    Height = height,
                });
            }
        }
    }
