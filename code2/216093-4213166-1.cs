    @functions{
       public static HtmlString Li(bool selected, Func<dynamic, object> template) {
          var result = string.Format("<li{0}>{1}</li>",
             selected ? " class='selected'" : "")),
             template(null));
          return new HtmlString(result);
       }
    }
    @* ... *@
    @Li(Model.Mode == "map", @Html.ActionLink("Map & Directions", MVC.Biz.Show(Model.SingleBiz.BizName, "map", string.Empty)))
