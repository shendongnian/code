    @foreach (var item in Model)
    {
        MvcHtmlString num = new MvcHtmlString(item.Number + "-" + item.SubNumber);
        <p>@num</p>
    }
 
