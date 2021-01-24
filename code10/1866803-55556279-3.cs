    var magazine = 
        _magazines.Where(mag => mag.Predicate(cboSource.Text))
                  .DefaultIfEmpty(new Magazine())
                  .First();
    TextBoxPublication.Text = magazine.Publication;
    TextBoxAbbreviation.Text = magazine.Abbreviation;
    TextBoxLanguage.Text= magazine.Language;
