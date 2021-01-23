    >         private class CustomViewEngine : RazorViewEngine
    >         {
    >             private static string[] NewPartialViewFormats = new[] {
    > "~/Views/Shared/{0}.cshtml" };
    > 
    >             public CustomViewEngine()
    >             {
    >                 base.PartialViewLocationFormats =
    > base.PartialViewLocationFormats.Union(NewPartialViewFormats).ToArray();
    >             }
    >         }
