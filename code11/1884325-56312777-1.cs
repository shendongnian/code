    dynamic myControl = control;
    try
    {
        myControl.Text = SPContext.Current.Web.Locale.LCID == 1033 ?
        DataBinder.Eval(keys.en, control.ID).ToString() :
        DataBinder.Eval(keys.sv, control.ID).ToString();
    }
    catch (Exception)
    {
        myControl.Text = "Key not found: " + control.ID;
    }
