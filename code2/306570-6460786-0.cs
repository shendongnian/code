    @model MvcSiteMapProvider.Web.Html.Models.SiteMapNodeModel
    @{   
        if (Model.IsCurrentNode && Model.SourceMetadata["HtmlHelper"].ToString() !="MvcSiteMapProvider.Web.Html.MenuHelper")
    {
            @Model.Title    
        }
        else if (Model.IsClickable)
        {
            <a href="@Model.Url" class="@(Model.IsInCurrentPath ? "current" : string.Empty)" target="@Model.TargetFrame" >@Model.Title</a>
        }
        else
        {
        @Model.Title
        }
    }
