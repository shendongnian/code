    private static bool NotEmpty(params TextBox[] textBoxes)
    {
        bool valid = true;
        foreach(var box in textBoxes)
        {
            if (String.IsNullOrEmpty(box.Text))
            {
                box.ForeColor = Color.Red;
                valid = false;
            }
        }
        return valid;
    }
