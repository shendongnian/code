        private void RemoveTimer(object sender, EventArgs e)
        {
            Button Delete = sender as Button;
            StackPanel stkButtonParent = Delete.Parent as StackPanel;
            StackPanel stkCover = stkButtonParent.Parent as StackPanel;
            DispatcherTimer timer = stkButtonParent.Tag as DispatcherTimer; 
            timer.Stop(); // stop timer
            stkCover.Children.Remove(stkButtonParent);
            Frame.MinHeight = Frame.MinHeight - 25;
        }
