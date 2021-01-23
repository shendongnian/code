    private void ShowForm(string name)
    {
        Form targetForm = null;
        foreach (Form frm in Application.OpenForms)
        {
            if (frm.Tag != null)
            {
                if (frm.Tag.ToString() == name)
                {
                    targetForm = frm;
                    break;
                }
            }
        }
        if (targetForm != null)
        {
            targetForm.Activate();
        }
        else
        {
            // create new form and show it
        }
    }
