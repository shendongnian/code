    @Html.DevExpress().GridView(
    settings =>
    {
        settings.Name = "GridView";
        settings.CallbackRouteValues = new { Controller = "DevExpessController", Action = "DevExpressViewPartial" };
        settings.KeyFieldName = "Clock";
        settings.Width = System.Web.UI.WebControls.Unit.Percentage(100);
        settings.SettingsPager.PageSize = 32;
        settings.Settings.VerticalScrollBarMode = ScrollBarMode.Visible;
        settings.Settings.VerticalScrollableHeight = 350;
        settings.ControlStyle.Paddings.Padding = System.Web.UI.WebControls.Unit.Pixel(0);
        settings.ControlStyle.Border.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(0);
        settings.ControlStyle.BorderBottom.BorderWidth = System.Web.UI.WebControls.Unit.Pixel(1);
        settings.Columns.Add("FirstName");
        settings.Columns.Add("LastName");
        settings.Columns.Add("Department");
        settings.Columns.Add("Title");
        settings.Columns.Add("PlantNO");
        settings.Columns.Add("Telephone");
        settings.Columns.Add("Mobile");
        settings.Columns.Add("Pager");
    }).Bind(Model).GetHtml()
