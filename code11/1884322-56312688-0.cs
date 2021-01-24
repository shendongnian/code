    string text = "";
    try
    {
        text = SPContext.Current.Web.Locale.LCID == 1033 ?
        DataBinder.Eval(keys.en, control.ID).ToString() :
        DataBinder.Eval(keys.sv, control.ID).ToString();
    }
    catch (Exception)
    {
        text = "Key not found: " + control.ID;
    }
    if (control is RadioButton) {
        (control as RadioButton).Text = text;
    } else if (control is Label) {
        (control as Label).Text = text;
    } else if (control is Button) {
        (control as Button).Text = text;
    }
