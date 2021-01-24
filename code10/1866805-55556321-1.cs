    var abbreviation = Path.GetFileNameWithoutExtension(cboSource.Text).Split("_")[0];
    if (Publications.ContainsKey(abbreviation)
    {
        TextBoxPublication.Text = Publications[abbreviation].Title;
        TextBoxAbbreviation.Text = abbreviation;
        TextBoxLanguage.Text = Publications[abbreviation].Language;
    }
