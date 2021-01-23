        private void GatherFormsData()
        {
            if (requestForm != null)
            {
                foreach (RequestForm rform in requestForm)
                {
                    if (rform.Visible)
                    {
                        WizardStepBase step = (WizardStep)wzAccessRequest.FindControl(rform.StepID);
                        FormUserControl form = (FormUserControl)step.FindControl(rform.ControlID);
                        rform.Results = String.Format("{0}<br>Email: {1}<br><br>", form.GetResults(), form.EmailContact());
                    }
                }
            }
        }
