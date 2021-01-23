    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    switch (e.CommandName)
    {
        case "Click":
        {
            string FirstColumnValue = e.CommandArgument.ToString();
            hiddenfield.Value = FirstColumnValue;
            break;
        }
        default:
            break;
    }
    }
