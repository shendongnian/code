    protected void YourLabel_PreRender(object sender, EventArgs e)
    {
        string LabelText = YourLabel.Text;
        bool NewForeColor = false;
    
        if (LabelText.Left(0, 1) == "@")
        {
            switch(LabelText.Substring(1, 1))
            {
                case "A":
                    YourLabel.ForeColor = System.Drawing.Color.Magenta;
                    NewForeColor = true;
                    break;
                case "B":
                    // you get the idea
                    break;
            }
            if (NewForeColor)
                YourLabel.Text = LabelText.Substring(2, LabelText.Length - 2);
        }
    }
