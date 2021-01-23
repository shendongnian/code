    Control control = gvr.Cells[0].Controls[0];
    string text = string.Empty;
    if (((ButtonField)gvClass.Columns[0]).ButtonType ==
        ButtonType.Link)
    {
        LinkButton btn = control as LinkButton;
        text = btn.Text;
    }
    else
    {
        Button btn = control as Button;
        text = btn.Text;
    }
