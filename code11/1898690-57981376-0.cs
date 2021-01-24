    private void ReportChangeStatus(TouchScreenKeyboard.Status newStatus)
    {
        if (newStatus == TouchScreenKeyboard.Status.Canceled)
            keepOldTextInField = true;
    }
    private void Editing(string currentText)
    {
        oldEditText = editText;
        editText = currentText;
    }
  
    private void EndEdit(string currentText)
    {
        if (keepOldTextInField && !string.IsNullOrEmpty(oldEditText))
        {
            //IMPORTANT ORDER
            editText = oldEditText;
            inputField.text = oldEditText;
            
            keepOldTextInField = false;
        }
    }
