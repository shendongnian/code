    public IEnumerable<string> AllTextsFromTextboxes()
    {
        foreach (var control in Page.Controls.OfType<TextBox>())
        {
            yield return control.Text;    
        }
    }
