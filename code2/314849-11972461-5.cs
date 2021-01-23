    @model List<WebpageWidgetTest.Models.Webpage>
    @{
        ViewBag.Title = "Home Page";
    }
    <h2>@ViewBag.Message</h2>
    <div>
        @{
            foreach (var webpage in Model)
            {
            <div>
                <h4>@webpage.Title</h4>
                <p>@webpage.Content</p>
                <p>Applicable Widgets:</p>
                @foreach (var widget in webpage.Widgets.OrderBy(w => w.Order))
                {
                    <div>
                        <h5>@widget.Widget.Title (@widget.Order)</h5>
                        <p>@widget.Widget.Content</p>
                    </div>
                }
            </div><hr /><br /><br />
            }
        }
    </div>
