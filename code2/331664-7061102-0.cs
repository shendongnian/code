      void SelectorRapidAccessKeyBehavior_DropDownOpened(object sender, EventArgs e)
        {
            FindPopup();
        }
        private void FindPopup()
        {
            CleanUpPopupHandler();
            pop = GetPopup(base.AssociatedObject);
            if (pop != null && pop.Child != null)
            {
                pop.Child.KeyDown += AssociatedObject_KeyUp;
                foreach (FrameworkElement c in Finder.FindVisualChildren<FrameworkElement>(pop.Child))
                {
                    c.KeyDown += new KeyEventHandler(c_KeyDown);
                }
            }
        }
        void c_KeyDown(object sender, KeyEventArgs e)
        {
            int t = this.AssociatedObject.TabIndex;
            Border ci = sender as Border;
            if (e.Key == Key.Tab)
            {
                if (ci != null)
                {
