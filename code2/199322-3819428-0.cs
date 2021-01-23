    private void SetImages(Control c)
    {
        foreach (Control curr in c.Controls)
        {
            if (curr.HasChildren) // for searching buttons in some containers
                SetImages(curr);
    
            if (curr.Name.Contains("button"))
            {
                int num = int.Parse(curr.Name.Replace("button", string.Empty));
                if (num >= 0 && num <= 8)
                {
                    // Add code thats sets the image for a button ((Button)c).XXXX
                }
            }
        }
    }
