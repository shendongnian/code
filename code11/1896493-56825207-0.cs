    public static class Routing
    {
        public static void Include(IApplicationBuilder app)
        {
            app.UseMvc(routes =>
            {
                // /
                routes.MapRoute(null, "", new
                {
                    controller = "Products",
                    action = "List",
                    category = "",
                    page = 1
                });
    
                // Page2
                routes.MapRoute(null,
                    "Page{page}",
                    new
                    {
                        controller = "Products",
                        action = "List",
                        category = ""
                    },
                    new { page = @"\d+" }
                );
            }
            );
        }
    }
