     public static IHtmlString HrefLangLinks(this BasePage currentPage)
        {
            IContentRepository repo = ServiceLocator.Current.GetInstance<IContentRepository>();
            var pageLanguagesBranches = repo.GetLanguageBranches<PageData>(currentPage.ContentLink).ToList();
            var availablePageLanguages = FilterForVisitor.Filter(pageLanguagesBranches).OfType<PageData>();
            // Dictionary<String, String>
            return null;
        }
