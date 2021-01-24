    // Define a list to store "O" and "X"
    List<string> result = new List<string>();
    for (int row = 0; row < ROWS; row++)
    {
        for (int col = 0; col < COLS; col++)
        {
            result.Add(gameBoard[row, col] == 0 ? "O" : "X");
        }
    }
    // Traverse the controls
    foreach (var i in Controls)
    {
        // Judge if is a label (label1 to label9, the length is 6)
        if (i is Label && ((Label)i).Name.Length == 6)
        {
            // Match the corresponding result
            for (int j = 1; j <= 9; j++)
            {
                // Match by last character of the label
                if (Convert.ToInt32(((Label)i).Name[5].ToString()) == j)
                {
                    ((Label)i).Text = result[j - 1];
                    break;
                }
            }
        }
    }
