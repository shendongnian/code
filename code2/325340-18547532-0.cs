    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    
    namespace SMART.Infrastructure
    {
        public static class Html
        {
            /// <summary>
            /// Creates and Action link with a clickable image instead of text.
            /// </summary>
            /// <param name="helper"></param>
            /// <param name="controller">Controller</param>
            /// <param name="action">Action</param>
            /// <param name="parameters">Parameters</param>
            /// <param name="src">Image source</param>
            /// <param name="alt">Alternate text(Optional)</param>
            /// <returns>An HTML anchor tag with a nested image tag.</returns>
            public static MvcHtmlString ActionImage(this HtmlHelper helper, String controller, String action , Object parameters, String src, String alt = "", String title = "")
            {
                TagBuilder tagBuilder = new TagBuilder("img");
                UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
                String url = urlHelper.Action(action, controller, parameters);
                String imgUrl = urlHelper.Content(src);
                String image = "";
                StringBuilder html = new StringBuilder();
    
                // build the image tag.
                tagBuilder.MergeAttribute("src", imgUrl);
                tagBuilder.MergeAttribute("alt", alt);
                tagBuilder.MergeAttribute("title", title);
                image = tagBuilder.ToString(TagRenderMode.SelfClosing);
    
                html.Append("<a href=\"");
                html.Append(url);
                html.Append("\">");
                html.Append(image);
                html.Append("</a>");
    
                return MvcHtmlString.Create(html.ToString());
            }
        }
    }
