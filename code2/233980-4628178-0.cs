    bool comboBoxASelected = !String.Equals(ComboBoxA.SelectedValue.ToString(), DEFAULT_COMBO_A_CHOICE.ToString());
    bool comboBSelected = !String.Equals(ComboBoxB.SelectedValue.ToString(), DEFAULT_COMBO_B_CHOICE.ToString());
    bool textBoxAHasContent = !String.IsNullOrEmpty(TextBoxA.Text);
    bool textBoxBHasContent = !String.IsNullOrEmpty(TextBoxB.Text);
    bool textBoxCHasContent = !String.IsNullOrEmpty(TextBoxC.Text);
    bool primaryInformationEntered = comboBoxASelected && textBoxAHasContent && comboBSelected;
    bool alternativeInformationEntered = textBoxBHasContent || textBoxCHasContent;
    
    if (primaryInformationEntered || alternativeInformationEntered)
    {
        //Do Some Validation
    }
