    public static class MyMenuHelper {
        public static string MyMenu(this HtmlHelper helper) {
            List<Category> categories = GetCategories();
            foreach ( Category c in categories ) {
                helper.RouteLink( c.Name, "AuctionCategoryDetails", new { categoryName = c.Name } );
            }
        }
    }
