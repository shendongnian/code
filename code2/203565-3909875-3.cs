    if (text1.Text == "")
    {
        if (text2.Text == "")
        {
            if (text3.Text == "")
            {
                if (text4.Text == "")
                {
                    M("1", "2", "3", "4");
                }
                else
                {
                    M("1", "2", "3", text4.Text);
                }
            }
            else
            {
                if (text4.Text == "")
                {
                    M("1", "2", text3.Text, "4");
                }
                else
                {
                    M("1", "2", text3.Text, text4.Text);
                }
            }
            ... about fifty more lines of this.
