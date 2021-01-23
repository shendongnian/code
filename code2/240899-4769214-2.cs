    @model AppName.Models.AddPostViewModel
    @{
        ViewBag.Title = "Home Page";
    }
    @using (Html.BeginForm())
    {
        @Html.DropDownListFor(x => x.Post.CategoryId, new SelectList(Model.Categories, "Value", "Text"), "-- Please select --")
        @Html.ValidationMessageFor(x => x.Post.CategoryId)
        <input type="submit" value="OK" />
    }
