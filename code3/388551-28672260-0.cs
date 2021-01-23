    <li><span>
    @{
        var lnk = Ajax.ActionLink("LinkText", "ControllerName", new AjaxOptions {
                     UpdateTargetId = "div",
                     InsertionMode = InsertionMode.Replace,
                     HttpMethod = "GET",
                     LoadingElementId = "progress"
                 });
    @Html.Raw(lnk.ToString().Replace(">LinkText<", "><span>LinkText</span><")); 
    // Remember to include the open and closing >< !
    }
    </span></li>
