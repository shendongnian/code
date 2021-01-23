    // 05-01-2010
    public static class WPFUIRefreshExtensionMethods
    {
        // www.tonysistemas.com.br
        private static System.Action EmptyDelegate = delegate() { };
        /// <summary>
        /// Força redesenhar
        /// mesmo que esteja dentro de um loop
        /// </summary>
        /// <param name="uiElement"></param>
        public static void Refresh(this System.Windows.UIElement uiElement)
        {
            //uiElement.UpdateLayout();
            uiElement.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Render, EmptyDelegate);
        }
    }
