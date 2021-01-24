    /// <summary>
    /// Class with extension methods for INavigation interface to help working with the modal page stack
    /// </summary>
    public static class ModalHelper
    {
        /// <summary>
        /// Unwinds the modal stack of the navigation until reaching a page with the given type
        /// </summary>
        /// <typeparam name="PageType"></typeparam>
        /// <param name="navigation">The navigation object of the current top page</param>
        /// <returns></returns>
        public async static Task UnwindModalStackTo<PageType>(this INavigation navigation) where PageType : Page
        {
            await navigation.UnwindModalStackTo(p => p is PageType);
        }
        /// <summary>
        /// Unwinds the modal stack of the navigation until reaching the given page 
        /// </summary>
        /// <param name="navigation">The navigation object of the current top page</param>
        /// <param name="page">The page where to stop unwinding the modal stack</param>
        public async static Task UnwindModalStackTo(this INavigation navigation, Page page) 
        {
            await navigation.UnwindModalStackTo(p => p == page);
        }
        /// <summary>
        /// Unwinds the modal stack of the navigation until reaching a page that fulfils the predicate
        /// </summary>
        /// <param name="navigation">The navigation object of the current top page</param>
        /// <param name="predicate">A function which tests whether to stop at a given page</param>
        public async static Task UnwindModalStackTo(this INavigation navigation, Func<Page, bool> predicate)
        {
            bool found = false;
            while (navigation != null && navigation.ModalStack.Count > 0)
            {
                // Get the current top page of the modal stack
                Page topPage = navigation.ModalStack[navigation.ModalStack.Count - 1];
                // Get the second page in the modal stack from the top (This one will become top next after we pop)
                Page parentPage;
                if (navigation.ModalStack.Count > 1)
                {
                    parentPage = navigation.ModalStack[navigation.ModalStack.Count - 2];
                }
                else
                {
                    parentPage = null;
                }
                // When the top page fulfills the predicate, stop
                if (predicate(topPage))
                {
                    found = true;
                    break;
                }
                // Pop the top page
                await navigation.PopModalAsync();
                // We need to use the navigation of the new top page from here on
                navigation = parentPage?.Navigation;
            }
            // When the target page was not found, throw an exception
            if (!found)
            {
                throw new Exception("Desired page not found in modal stack");
            }
        }
    }
