    public static Form IsFormAlreadyOpen(Type FormType)
    {
        foreach (Form OpenForm in System.Windows.Forms.Application.OpenForms)
        {
            if (OpenForm.GetType() == FormType)
                return OpenForm;
        }
        return null;
    }
