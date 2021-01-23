       private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (this.Orientation == PageOrientation.Portrait)
            {
                optionsup.VerticalOffset = 447;
                optionsup.HorizontalOffset = 585;
            }
            else
            {
                optionsup.VerticalOffset = 585;
                optionsup.HorizontalOffset = 447;
            }
        }
