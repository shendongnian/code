    public static IHtmlString HrefLangLinks(this BasePage currentPage)
            {
                var pageLanguagesBranches = ContentRepository.GetLanguageBranches<PageData>(currentPage.ContentLink).ToList();
                var availablePageLanguages = FilterForVisitor.Filter(pageLanguagesBranches).OfType<PageData>();
    
                // Dictionary<String, String>
                return null;
            }
