    private IViewData CreateViewData()
    {
        IViewData viewData;
        switch (outputMedia)
        {
            case "Excel":
                viewData = new ExcelOutput(operation, study);
                break;
            case "Spotfire":
                viewData = new SpotfireOutput(operation, study);
                break;
        }
        return viewData;
    }
    ...
    private void ConfirmButton_Click(object sender, EventArgs e)
    {
        IViewData viewData = CreateViewData();
        viewData.DisplayData();
    }
