    public class MyViewEngine : RazorViewEngine // WebFormViewEngine - if you are using WebForms
    {
        public MyViewEngine()
        {
            ViewLocationFormats = base.ViewLocationFormats.Union(new[] 
            {
                "~/Views/Base/{0}.cshtml",
                "~/Views/Base/{0}.vbhtml",
                "~/Views/Base/{0}.aspx",
                "~/Views/Base/{0}.ascx",
            }).ToArray();
        }
    }
