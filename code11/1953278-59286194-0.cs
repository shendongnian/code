    public void RefreshGridView()
    {
        List<myClass> result = getAllElementsClassFunction();
        grdUser.DataSource = result;
        grdUser.DataBind();
    }
