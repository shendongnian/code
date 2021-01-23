        //Originally posted by CleverCode - http://forums.silverlight.net/post/63607.aspx
        public static void PushToTop(this FrameworkElement element)
        {
            if (element == null) throw new ArgumentNullException("element");
            var parentPanel = element.Parent as Panel;
            if (parentPanel != null)
            {
                // relocate the framework element to be the last in the list (which makes it "above" everything else)
                parentPanel.Children.Remove(element);
                parentPanel.Children.Add(element);
                parentPanel.UpdateLayout();
            }
        }
