    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    namespace MyProjectNamespace
    {
        public static class HtmlHelpers
        {
            private const string ScriptsKey = "DelayedScripts";
    
            public static IDisposable BeginScripts(this IHtmlHelper helper)
            {
                return new ScriptBlock(helper.ViewContext);
            }
    
            public static HtmlString PageScripts(this IHtmlHelper helper)
            {
                return new HtmlString(string.Join(Environment.NewLine, GetPageScriptsList(helper.ViewContext.HttpContext)));
            }
    
            private static List<string> GetPageScriptsList(HttpContext httpContext)
            {
                var pageScripts = (List<string>)httpContext.Items[ScriptsKey];
                if (pageScripts == null)
                {
                    pageScripts = new List<string>();
                    httpContext.Items[ScriptsKey] = pageScripts;
                }
                return pageScripts;
            }
    
            private class ScriptBlock : IDisposable
            {
                private readonly TextWriter _originalWriter;
                private readonly StringWriter _scriptsWriter;
    
                private readonly ViewContext _viewContext;
    
                public ScriptBlock(ViewContext viewContext)
                {
                    _viewContext = viewContext;
                    _originalWriter = _viewContext.Writer;
                    _viewContext.Writer = _scriptsWriter = new StringWriter();
                }
    
                public void Dispose()
                {
                    _viewContext.Writer = _originalWriter;
                    var pageScripts = GetPageScriptsList(_viewContext.HttpContext);
                    pageScripts.Add(_scriptsWriter.ToString());
                }
            }
        }
    }
