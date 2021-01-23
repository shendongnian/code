    private void CloseAllForms()
    {
        Form[] formToClose = null;
        int i = 1;
        foreach (Form form in Application.OpenForms)
        {
            if (form != this) //this is form1
            {
                Array.Resize(ref formToClose, i);
                formToClose[i - 1] = form;
                i++;
            }
        }
        if (formToClose != null)
            for (int j = 0; j < formToClose.Length; j++)
                formToClose[j].Dispose();
    }
