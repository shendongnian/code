        public static void SetDatailPage(Page page)
        {
            if (App.Current.MainPage is MasterDetailPage)
            {
                var masterPage = (MasterDetailPage)App.Current.MainPage;
                masterPage.Detail = new NavigationPage(page);
            }
        }
