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
    //this here is the magic line
                    var v = Finder.FindVisualChildren<FrameworkElement>((DependencyObject)pop.Child).Where(a => a.Opacity > 0 && a.Name == "FocusVisualElement" && a.Visibility == Visibility.Visible);//&& )
                    object o = v.First().DataContext;
                    int i = this.AssociatedObject.Items.IndexOf(o);
                    if (i > -1)
                        this.AssociatedObject.SelectedIndex = i;
                    pop.IsOpen = false;
                    DependencyObject d = Finder.FindParent<FloatableWindow>(this.AssociatedObject);
                    if (d == null)
                        d = Finder.FindParent<Window>(this.AssociatedObject);
                    Control c = Finder.FindVisualChildren<Control>(d).Where(a => a.TabIndex > t).OrderBy(a => a.TabIndex).FirstOrDefault();
                    if (c == null)
                        c = Finder.FindVisualChildren<Control>(d).OrderBy(a => a.TabIndex).FirstOrDefault();
                    if (c != null)
                        c.Focus();
                }
            }
        }
