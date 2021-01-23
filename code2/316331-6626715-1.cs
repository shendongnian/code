        private void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Checked = false;
                ClearInputs(ctrl.Controls);
            }
        }
        protected void YourWizardName_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            ClearInputs(YourWizardName.WizardSteps[e.CurrentStepIndex].Controls);
        }
