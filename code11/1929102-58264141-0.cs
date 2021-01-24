            services.Configure<RazorViewEngineOptions>(o =>
            {
                
                o.ViewLocationFormats.Clear();
                o.ViewLocationFormats.Add("/UI/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/UI/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
                o.AreaPageViewLocationFormats.Clear();
                o.AreaPageViewLocationFormats.Add("/UI/Areas/Identity/Pages/{1}/{0}" + RazorViewEngine.ViewExtension);
            });
