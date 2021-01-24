    public object SetChecked(bool value)
    {
        if (value)
        {
            return new { id = "allowOrder", @checked = "checked" };
        }
        else
        {
            return new { id = "allowOrder" };
        }
    }
