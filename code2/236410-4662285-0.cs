    RadGrid.DataSource = Method(x);
    if (Method(x).Any())
    {
        button.Enabled = true;
    }
    else
    {
        button.Enabled = false;
    }
