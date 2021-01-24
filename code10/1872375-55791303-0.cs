     public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{query}",
                defaults: new { controller = "AnaSayfa", action = "Index", query = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Dosya",
                url: "{controller}/{action}/{Id}/{query}",
                defaults: new { controller = "Home", action = "Index", query = UrlParameter.Optional },
                constraints: new { Id = "\\d+" }
            );
            routes.MapRoute(
         name: "Dosya Duzenle History",
         url: "{controller}/{action}/{query}/{ishistory}/{Id}",
         defaults: new { controller = "Dosya", action = "DosyaDuzenle", ishistory = UrlParameter.Optional, query = UrlParameter.Optional },
           constraints: new { Id = "\\d+" }
     );
            routes.MapRoute(
                name: "Dosya Versiyon Ekle",
                url: "{controller}/{action}/{Id}/{query}/{ParentRaporId}",
                defaults: new { controller = "Dosya", action = "DosyaVersiyonEkle", query = UrlParameter.Optional },
                constraints: new { Id = "\\d+", ParentRaporId = "\\d+" }
            );
            routes.MapRoute(
               name: "History",
               url: "{controller}/{action}/{ishistory}/{query}",
               defaults: new { controller = "AnaSayfa", action = "Index", ishistory = UrlParameter.Optional, query = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "raporPaylasim",
               url: "{controller}/{action}/{kod}/{tarih}/{optional}",
               defaults: new
               {
                   controller = "Rapor",
                   action = "RaporPaylasim"
                   ,
                   kod = UrlParameter.Optional
                   ,
                   tarih = UrlParameter.Optional
                   ,
                   optional = UrlParameter.Optional
               }
               ///, constraints: new { kategoriKod = "[a-zA-Z0-9._-]+" }
           );
        }
    }
