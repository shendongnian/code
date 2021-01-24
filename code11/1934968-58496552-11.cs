    @model WebApplication6.Models.SearchViewModel
    @using WebApplication6.Models;
    @{
        ViewBag.Title = "Index";
    }
    <form>
        @{
            int i = 0;
            if (Model.Categories != null)
            {
                foreach (var item in Model.Categories)
                {
                    <input type="hidden" name="categories.categories[@i].Category" value="@item.Category" />
                    i++;
                }
            }
            <input type="hidden" name="category" value="Abdallah Hiekal" />
            <input type="submit" name="Click me!" />
        }
    </form>
    <!--print-->
    @if (Model.Categories != null)
    {
        foreach (var item in Model.Categories)
        {
            <div>
                @item.Category
                <hr />
            </div>
        }
    }
    <!--end print-->
    <h2>Index</h2>
    @Model.Categories.Count()
