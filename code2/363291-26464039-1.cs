    context.MapRoute(
                    "Admin_default",
                    "Admin/{controller}/{action}/{id}",
                    new { action = "Index", id = UrlParameter.Optional },
                    new[] { "MyNamespace.Areas.Admin.Controllers" }
                );
