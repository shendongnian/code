     public static MvcHtmlString IconImg(this HtmlHelper htmlHelper, string icon, string title = "", string size = "16x16") {
            string path = VirtualPathUtility.ToAbsolute("~/res/img/icons/" + size + "/" + icon + ".png");
            string imgHtml = "<img src='" + path + "' title='" + title + "' style='border:none' />";
            return new MvcHtmlString(imgHtml);
        }
