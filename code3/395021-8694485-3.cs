    public static class HtmlExtensions
    {
        public static IHtmlString Link(this HtmlHelper htmlHelper, MyViewModel item)
        {
            var anchor = new TagBuilder("a");
            anchor.AddCssClass("test");
            anchor.Attributes["src"] = "#";
            anchor.Attributes["onclick"] = string.Format(
                "alert({0});", Json.Encode(item.CarrierName)
            );
            anchor.SetInnerText(item.CarrierName);
            return new HtmlString(anchor.ToString());
        }
    }
