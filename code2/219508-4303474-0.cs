    public void ResetForm(ControlCollection objSiteControls)
        {
            foreach (Control objCurrControl in objSiteControls)
            {
                string strCurrControlName = objCurrControl.GetType().Name;
                if (objCurrControl.HasControls())
                {
                    ResetForm(objCurrControl.Controls);
                }
                switch (strCurrControlName)
                {
                    case "TextBox":
                        TextBox objTextBoxControl = (TextBox)objCurrControl;
                        objTextBoxControl.Text = string.Empty;
                        break;
                    case "DropDownList":
                        DropDownList objDropDownControl = (DropDownList)objCurrControl;
                        objDropDownControl.SelectedIndex = -1;
                        break;
                    case "GridView":
                        GridView objGridViewControl = (GridView)objCurrControl;
                        objGridViewControl.SelectedIndex = -1;
                        break;
                    case "CheckBox":
                        CheckBox objCheckBoxControl = (CheckBox)objCurrControl;
                        objCheckBoxControl.Checked = false;
                        break;
                    case "CheckBoxList":
                        CheckBoxList objCheckBoxListControl = (CheckBoxList)objCurrControl;
                        objCheckBoxListControl.ClearSelection();
                        break;                    
                    case "RadioButtonList":
                        RadioButtonList objRadioButtonList = (RadioButtonList)objCurrControl;
                        objRadioButtonList.ClearSelection();
                        break;
                }
            }
        }
