    public class WebWidgetTestContext : DbContext
        {
            public DbSet<Webpage> Webpages { get; set; }
            public DbSet<Widget> Widgets { get; set; }
            public DbSet<IndexedWebpageWidget> WebpageWidgets { get; set; }
        }
    
        public class WebWidgetInitialiser : DropCreateDatabaseIfModelChanges<WebWidgetTestContext>
        {
            protected override void Seed(WebWidgetTestContext context)
            {
                //
                // create 3 pages
                //
    
                var webpageA = new Webpage
                {
                    Title = "Webpage A",
                    Content = "Content for Webpage A",
                    Widgets = new List<IndexedWebpageWidget>()
                };
    
                var webpageB = new Webpage
                {
                    Title = "Webpage B",
                    Content = "Content for Webpage B",
                    Widgets = new List<IndexedWebpageWidget>()
                };
                
                var webpageC = new Webpage
                {
                    Title = "Webpage C",
                    Content = "Content for Webpage C",
                    Widgets = new List<IndexedWebpageWidget>()
                };
    
    
                //
                // create 3 widgets
                //
    
                var widget1 = new Widget
                {
                    Title = "Widget 1",
                    Content = "Content for Widget 1",
                    Webpages = new List<IndexedWebpageWidget>()
                };
    
                var widget2 = new Widget
                {
                    Title = "Widget 2",
                    Content = "Content for Widget 2",
                    Webpages = new List<IndexedWebpageWidget>()
                };
    
                var widget3 = new Widget
                {
                    Title = "Widget 3",
                    Content = "Content for Widget 3",
                    Webpages = new List<IndexedWebpageWidget>()
                };
    
    
                // now match them up
    
                var map1 = new IndexedWebpageWidget
                {
                    Webpage = webpageA,
                    Widget = widget1,
                    Order = 1
                };
    
                var map2 = new IndexedWebpageWidget
                {
                    Webpage = webpageA,
                    Widget = widget2,
                    Order = 2
                };
    
                var map3 = new IndexedWebpageWidget
                {
                    Webpage = webpageB,
                    Widget = widget1,
                    Order = 1
                };
    
                var map4 = new IndexedWebpageWidget
                {
                    Webpage = webpageB,
                    Widget = widget3,
                    Order = 3
                };
    
                var map5 = new IndexedWebpageWidget
                {
                    Webpage = webpageC,
                    Widget = widget2,
                    Order = 2
                };
    
                var map6 = new IndexedWebpageWidget
                {
                    Webpage = webpageC,
                    Widget = widget3,
                    Order = 1
                };
    
                // add
                context.WebpageWidgets.Add(map1);
                context.WebpageWidgets.Add(map2);
                context.WebpageWidgets.Add(map3);
                context.WebpageWidgets.Add(map4);
                context.WebpageWidgets.Add(map5);
                context.WebpageWidgets.Add(map6);
    
                // save
                context.SaveChanges();
    
            }
        }
