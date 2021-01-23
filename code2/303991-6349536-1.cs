    [JustInTimeActivation(true)]
    public class MenuManager : ServicedComponent
    {
        public void GetMenuPageInfo(string PubCode, 
             int Page, 
             out string menuPageUrl, 
             out int menuCode)
        {
            ContextUtil.DeactivateOnReturn = true;
            menuPageUrl = null;
            menuCode = 0;
            MenuPage ReturnMenuPage;
            if (Menus.MenuPages.TryGetValue(
                    String.Concat(PubCode, Page.ToString()), out ReturnMenuPage))
            {
                menuPageUrl = ReturnMenuPage.MenuPageUrl;
                menuCode = ReturnMenuPage.Code;
            }
        }
    }
