        if (FireFormView.Row != null)
        {
            if (FireFormView.CurrentMode == FormViewMode.ReadOnly)
            {
                Panel pnl = (Panel)FireFormView.FindControl("pnl");
            }
            else
            {
                //FormView is not in readonly mode
            }
        }
        else
        {
            //formview not databound, check select statement and parameters.
        }
