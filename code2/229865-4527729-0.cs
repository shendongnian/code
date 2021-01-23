    var selectedCriteria = cmbType.SelectedItem as ICriteria;
    if (typeof(IChoices).IsAssignableFrom(selectedCriteria.GetType()))
    {
        IChoices criteria = selectedCriteria as IChoices;
        SaveMultipleChoiceValues(criteria);
    }
    else if(typeof(ITextCriteria).IsAssignableFrom(selectedCriteria.GetType()))
    {
        if (selectedCriteria.GetCriteriaType() == CriteriaTypes.None)
        {
            return;
        }
    }
