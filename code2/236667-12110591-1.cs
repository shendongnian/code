            private void EnableControls(Control control)
            {
                var textbox = control as TextBox;
                if (textbox != null)
                {
                    textbox.Enabled = true;
                }
    
                var dropDownList = control as DropDownList;
                if (dropDownList != null)
                {
                    dropDownList.Enabled = true;
                }
    
                var radioButton = control as RadioButton;
                if (radioButton != null)
                {
                    radioButton.Enabled = true;
                }
    
                var checkBox = control as CheckBox;
                if (checkBox != null)
                {
                    checkBox.Enabled = true;
                }
    
                foreach (Control childControl in control.Controls)
                {
                    EnableControls(childControl);
                }
    
            }
