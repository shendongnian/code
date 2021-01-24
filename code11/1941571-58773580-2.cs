    @model IEnumerable<MvcTesProject.Models.Modules.ModulesModel>
    
    @{
        ViewBag.Title = "Index";
    }
    
    @if (Model.Count() > 0)
    {
        <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        @foreach (var item in Model)
                        {
                            @*<li>@Html.ActionLink("TEST ", "Index", "NoFab")</li>*@
                            <li><a href="@item.Uri">@item.DisPlayName</a></li>
                        }
                    </ul>
                </div>
            </div>
        </div>
    }
    
