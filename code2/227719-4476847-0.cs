    routes.MapRoute("Images",
                "/images/{filename}",
                new { controller = "Image", action = "Resize" });
    /sitebase/images/image.jpg         //public image location
    /sitebase/content/images/image.jpg //real image location
