    public bool TextBox_Validation(string sender) {
            return !string.IsNullOrEmpty(sender);
    }
    
            if(TextBox_Validation(textbox1.Value)) {
                 //OK
             } else { 
                MessageBox.Show("Please enter a value");
                 //ETC
            }
