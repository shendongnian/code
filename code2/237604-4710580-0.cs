    delegate void SetBoolDelegate(bool parameter); 
    //  This would be your timer tick event handler...
    void SetInputEnabled(bool enabled) {
        if(!InvokeRequired) {
            button1.Enabled=enabled; 
            comboBoxDigits.Enabled=enabled; 
            numericUpDownDigits.Enabled=enabled;
        } 
        else {
            Invoke(new SetBoolDelegate(SetInputEnabled),new object[] {enabled}); 
        }
    } 
