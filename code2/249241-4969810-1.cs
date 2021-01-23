    // Start by setting preview to the same text as question.
    preview.Text = question.Text;
    
    for (int i = 0; i < chosenwordlist.Items.Count; ++i)
    {
        string word = chosenwordlist.Items[i].ToString();
    
        // Notice the verbatim literal (@) for the SECOND "\b" as well.
        string pattern = @"\b"+ word + @"\b";
    
        // Since the text in your question TextBox isn't changing, you need to base each
        // replacement off of what's in the preview TextBox, which IS (changing).
        preview.Text = Regex.Replace(preview.Text, pattern, "__________");
    }
