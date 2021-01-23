    switch (fvReport.CurrentMode)
    {
        case FormViewMode.Edit:
            fvReport.AllowPaging = false;
            lbl.Text = "Update!!!";
            fvReport.ChangeMode(FormViewMode.ReadOnly);
            fvReport.DataBind();
            break;
    }
    fvReport.DataBind();
