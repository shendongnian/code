    @inherits System.Web.Mvc.WebViewPage<IList<License>>
    @Html.ListBoxFor(x => x,
                    new MultiSelectList((List<License>)ViewBag.LicenseAll,
                    "Id",
                    "LicenseName",
                    Model))
