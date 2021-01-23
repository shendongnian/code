    public static string DisplayMenu(this HtmlHelper helper, NavigationModel navigationMenu)
    { 
    	public static string DisplayMenu(this HtmlHelper helper, NavigationModel navigationMenu)
        {            
            String result = "<ul id='main-nav'>\n";
            foreach(Menu menu in navigationMenu.Menus)
            {
                result +=     "<li>\n";
                result +=         string.Format("<a href='#'> {0} </a>\n",helper.AttributeEncode(menu.Name));
                result +=         "<ul>\n";
                foreach(MenuItem item in menu.MenuItems)
                {
                    result += NavigationHelper.ConvertToItem(helper, item);
                }
                result +=         "</ul>\n";
                result +=     "</li>\n";
            }
            result +=     "</ul>\n";
            return result;
        }
        private static string ConvertToItem(this HtmlHelper helper,MenuItem item)
        {
            if (item.Show)
            {
                return string.Format("<li><a href='{0}'>{1}</a></li>\n", helper.AttributeEncode(item.Link), helper.AttributeEncode(item.Label));
            }
            else { return ""; }   
        }
    }
