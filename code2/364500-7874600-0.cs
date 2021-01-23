    public new event System.ComponentModel.CancelEventHandler Validating
    {
        add
        {
            innerTextBox.Validating += value;
            innerComboBox.Validating += value;
        }
    
        remove 
        { 
            innerTextBox.Validating -= value; }
            innerComboBox.Validating -= value; }
        }
    }
