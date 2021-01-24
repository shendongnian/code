        public void Path_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is FrameworkElement fe)
                VisualStateManager.GoToElementState(fe, "MouseEnter", true);
        }
        public void Path_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is FrameworkElement fe)
                VisualStateManager.GoToElementState(fe, "MouseLeave", true);
        }
