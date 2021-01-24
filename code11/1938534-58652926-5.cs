    // You might need to set some standard sizes for the Map controls
    private int mapHeight = 50;
    private int mapWidth = 300;
    // Not sure where these are actually defined
    private int rows;
    private int cols;
    private void openButton_Click(object sender, EventArgs e)
    {
        var ofg = new OpenFileDialog {Filter = "Game File(*.game)|*.game;"};
        if (ofg.ShowDialog() == DialogResult.OK)
        {
            // Read all our lines into an array
            var lines = File.ReadAllLines(ofg.FileName);
            // And now do the opposite of how we created the text file:
            // First, set the rows and cols based on the first line
            // (some validation should be done here, but this works with "3,3")
            var rowsCols = lines[0].Split(',');
            int.TryParse(rowsCols[0], out rows);
            int.TryParse(rowsCols[1], out cols);
            // Next, create Maps from the rest of the lines and add them to our controls
            // Note we should validate that lines.Length = rows * cols + 1
            var line = 1; // This gets incremented below, so we read each line
            for (int row = 0; row < rows; row ++)
            {
                for (int col = 0; col < cols; col++)
                {
                    // Create a map from the line, row, and column using our new method
                    var map = Map.Parse(lines[line++], row, col);
                    // Set the layout by rows and columns (?)
                    map.Width = mapWidth;
                    map.Height = mapHeight;
                    map.Left = (col + 1) * mapWidth;
                    map.Top = (row + 1) * mapHeight;
                    // Hook up the Click event so our images load on click
                    map.Click += square_Click;
                    // Add the control to our panel
                    pnlGameBoard.Controls.Add(map);
                }
            }
        }
    }
