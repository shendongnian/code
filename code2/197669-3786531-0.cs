    using System;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Collections.Specialized;
    using System.Collections.Generic;
    
    namespace MVC2_NASTEST.Helpers {
        public static class ActionLinkwParamsExtensions {
            public static MvcHtmlString ActionLinkwParams(this HtmlHelper helper, string linktext, string action, string controller, object extraRVs, object htmlAttributes) {
    
                NameValueCollection c = helper.ViewContext.RequestContext.HttpContext.Request.QueryString;
    
                RouteValueDictionary r = new RouteValueDictionary();
                foreach (string s in c.AllKeys) {
                    r.Add(s, c[s]);
                }
    
                RouteValueDictionary htmlAtts = new RouteValueDictionary(htmlAttributes);
    
                RouteValueDictionary extra = new RouteValueDictionary(extraRVs);
    
                RouteValueDictionary m = Merge(r, extra);
    
                return System.Web.Mvc.Html.LinkExtensions.ActionLink(helper, linktext, action, controller, m, htmlAtts);
            }
    
            public static MvcHtmlString ActionLinkwParams(this HtmlHelper helper, string linktext, string action) {
                return ActionLinkwParams(helper, linktext, action, null, null, null);
            }
    
            public static MvcHtmlString ActionLinkwParams(this HtmlHelper helper, string linktext, string action, string controller) {
                return ActionLinkwParams(helper, linktext, action, controller, null, null);
            }
    
            public static MvcHtmlString ActionLinkwParams(this HtmlHelper helper, string linktext, string action, object extraRVs) {
                return ActionLinkwParams(helper, linktext, action, null, extraRVs, null);
            }
    
            public static MvcHtmlString ActionLinkwParams(this HtmlHelper helper, string linktext, string action, string controller, object extraRVs) {
                return ActionLinkwParams(helper, linktext, action, controller, extraRVs, null);
            }
    
            public static MvcHtmlString ActionLinkwParams(this HtmlHelper helper, string linktext, string action, object extraRVs, object htmlAttributes) {
                return ActionLinkwParams(helper, linktext, action, null, extraRVs, htmlAttributes);
            }
    
    
    
    
            static RouteValueDictionary Merge(this RouteValueDictionary original, RouteValueDictionary @new) {
    
                // Create a new dictionary containing implicit and auto-generated values
                RouteValueDictionary merged = new RouteValueDictionary(original);
    
                foreach (var f in @new) {
                    if (merged.ContainsKey(f.Key)) {
                        merged[f.Key] = f.Value;
                    } else {
                        merged.Add(f.Key, f.Value);
                    }
                }
    
                return merged;
    
            }
        }
    
    }
