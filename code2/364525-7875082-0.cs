    string status = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MessageActive"));
    if (status == "No")
    {
        e.Row.BackColor = Drawing.Color.Red
    }
