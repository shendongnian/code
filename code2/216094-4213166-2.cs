    @functions{
       public HtmlString Li(bool selected, IHtmlString template) {
          var result = string.Format("<li{0}>{1}</li>",
             selected ? " class='selected'" : "")),
             template);
          return new HtmlString(result);
       }
    }
    @* ... *@
    @Li(Model.Mode == "map", Html.ActionLink("Map & Directions", MVC.Biz.Show(Model.SingleBiz.BizName, "map", string.Empty)))
