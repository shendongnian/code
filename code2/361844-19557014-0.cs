    LinkButton Btn= (LinkButton)e.Row.FindControl("BtnDelete");
    if (Btn!= null)
    {
             Btn.Attributes.Add("ROW_INDEX", e.Row.RowIndex.ToString());
    }
