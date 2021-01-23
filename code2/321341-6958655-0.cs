    string GetBlockUIText(BlockUIContainer blockUIContainer)
    {
        StringBuilder s = new StringBuilder();
        var line = blockUIContainer.Child as Panel;
        foreach (TextBlock child in line.Children)
        {
            s.Append(child.Text + " ");
        }
        return s.ToString();
    }
