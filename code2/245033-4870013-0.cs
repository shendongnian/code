    private void SourceAndBind(DropDownList d, Func<IEnumerable<object>> businessLayerMethod)
    {
        d.DataSource = businessLayerMethod();
        d.DataBind();
    }
