    public void catchNonNumeric()
    {
        checker = true;
        var textBoxes = new List<TextBox> 
            {txtBxStudentInput, txtBxPCInput, txtBxStuTourInput, txtBx203A, txtBx203F};
        foreach (var textBox in textBoxes)
        {
            int parsedValue;
            if (int.TryParse(textBox.Text, out parsedValue))
            {
                textBox.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
            }
            else
            {
                checker = false;
                textBox.ForeColor = Color.Red;
            }
        }          
    }
