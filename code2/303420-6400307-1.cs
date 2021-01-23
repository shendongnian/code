            private void Button_Click(object sender, RoutedEventArgs e)
        {
            slider.Visibility = Visibility.Visible;
            slider.Value = 1;
            // get the mouse positions
            string x = Mouse.GetPosition(this).X.ToString();
            string y = Mouse.GetPosition(this).Y.ToString();
            
            // convert the mouse position to a double
            var X = Convert.ToDouble(x);
            var Y = Convert.ToDouble(y);
            // reset the slider transform and apply the coordinates of the mouse position.
            mySliderTransform.X = 0;
            mySliderTransform.Y = 0;
            mySliderTransform.X = X - 20;
            mySliderTransform.Y = Y;
        }
