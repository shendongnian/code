    public static IHtmlString DropDowntListForVisitingAddress(
        this HtmlHelper<MyViewModel> html,
        Func<VisitingAddress, string> value,
        Func<VisitingAddress, string> text
    )
    {
        MyViewModel model = html.ViewData.Model;
        var values = model.VisitingAddresses.Select(x => new SelectListItem
        {
            Value = value(x),
            Text = text(x)
        });
        var selectList = new SelectList(values, "Value", "Text");
        return html.DropDownListFor(
            x => x.SelectedAddress,
            selectList
        );
    }
