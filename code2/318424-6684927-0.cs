        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            var gt = Window.GetWindow(this) as GetStarted;
            if (gt != null)
            {
                gt.image0.Visibility = Visibility.Visible;
                gt.lblSteps.Content = "Step 2 of 5";
            }
        }
